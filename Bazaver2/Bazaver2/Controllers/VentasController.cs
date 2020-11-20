using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bazaver2.Classes;
using Bazaver2.Models;
using Bazaver2.ViewModel;
using PagedList;
// SDK de Mercado Pago 
using MercadoPago;
using MercadoPago.Resources;
using MercadoPago.DataStructures.MerchantOrder;
using MercadoPago.Common;
using Newtonsoft.Json;

namespace Bazaver2.Controllers
{
    public class VentasController : Controller
    {
        private Bazaver2DbContext db = new Bazaver2DbContext();

        // GET: Ventas
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var ventas = db.Ventas.Include(v => v.Localidad).OrderByDescending(v => v.VentaId).ToList();
            var details = db.DetallesVentas.ToList();
            string query = "select TOP 5 V.Fecha, SUM(DV.Precio * Dv.Cantidad) as Recaudado from Ventas V right join DetallesVentas DV on V.VentaID = DV.VentaId group by V.Fecha order by V.Fecha desc";
            List<CajaDiaria> data = db.Database.SqlQuery<CajaDiaria>(query).ToList();
            if (data.Count == 0)
            {
                var asd = new CajaDiaria();
                asd.Fecha = DateTime.Today;
                asd.Recaudado = 0;
                data.Add(asd);

            }
            string query2 = "select TOP 5 Month(V.Fecha) as Mes, YEAR(V.Fecha) as Año, SUM(DV.Precio * DV.Cantidad) as Recaudado from Ventas V right join DetallesVentas DV on V.VentaID = DV.VentaId group by V.Fecha order by V.Fecha desc";
            List<CajaMensual> cajaMensual = db.Database.SqlQuery<CajaMensual>(query2).ToList();
            if (cajaMensual.Count == 0)
            {
                var asd = new CajaMensual();
                asd.Año = 2020;
                asd.Mes = 10;
                asd.Recaudado = 0;
                cajaMensual.Add(asd);
            }
            string query3 = "select SUM(DV.Precio * DV.Cantidad) as Recaudado from Ventas V right join DetallesVentas DV on V.VentaID = DV.VentaId";
            List<CajaTotal> cajatotal = db.Database.SqlQuery<CajaTotal>(query3).ToList();

            var ventaViewM = new VentasViewModel
            {
                cajaTotals = cajatotal,
                cajaMensuals = cajaMensual,
                cajaDiarias = data,
                VentasList = ventas,
                DetallesVentas = details,
            };
            return View(ventaViewM);


        }

        // GET: Ventas/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var details2 = db.DetallesVentas.Where(s => s.VentaId == id).ToList();
            var saleViewModel = new VentasViewModel { };
            saleViewModel.DetallesVentas = details2;
            if (details2 == null)
            {
                return HttpNotFound();
            }
            return View(saleViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {

            var cookie = Request.Cookies["your-cart-id"];
            if (cookie == null)
            {
                throw new ArgumentNullException("Cart cookie cannot be null!!");
            }
            var cartId = Guid.Parse(cookie?.Value);
            var newProduct = new VentasViewModel();

            var details = db.DetallesVentaTMPs.Where(pdt => pdt.CartId == cartId).ToList();
            newProduct.DetallesVentas2 = details;
            ViewBag.LocalidadId = new SelectList(db.Localidads, "LocalidadId", "Name");
            return View(newProduct);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AlmostThere(VentasViewModel ventasViewModel, int? asd = null)
        {

            asd = 1;
            var cookie = Request.Cookies["your-cart-id"];

            if (cookie == null)
            {
                throw new ArgumentNullException("Cart cookie cannot be null!!");
            }

            var cartId = Guid.Parse(cookie?.Value);

            var details = db.DetallesVentaTMPs.Where(pdt => pdt.CartId == cartId).ToList();
            ventasViewModel.DetallesVentas2 = details;

            if (ModelState.IsValid)
            {

                if (details.Count > 0)
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var sale = new Venta()
                            {
                                NombreCliente = ventasViewModel.NombreCliente,
                                ApellidoCliente = ventasViewModel.ApellidoCliente,
                                LocalidadId = ventasViewModel.LocalidadId,
                                Direccion = ventasViewModel.Direccion,
                                Comentarios = ventasViewModel.Comentarios,
                                Telefono = ventasViewModel.Telefono,
                                Correo = ventasViewModel.Correo,
                                Fecha = ventasViewModel.Fecha,
                                Estado = "Pendiente",
                            };

                            db.Ventas.Add(sale);
                            db.SaveChanges();

                            foreach (var item in ventasViewModel.DetallesVentas2)
                            {
                                var producto = db.Productos.Find(item.ProductoId);

                                var saleDetail = new DetallesVenta()
                                {
                                    Descripcion = producto.Descripcion,

                                    Cantidad = item.Cantidad,
                                    ProductoId = item.ProductoId,
                                    ColorId = item.ColorId,
                                    VentaId = sale.VentaId,
                                };
                                if (User.IsInRole("Admin"))
                                {
                                    saleDetail.Precio = producto.PrecioMay;
                                }
                                else
                                {
                                    saleDetail.Precio = producto.PrecioMin;
                                }
                                db.DetallesVentas.Add(saleDetail);

                                var productostock = db.Inventarios.FirstOrDefault(i => i.ProductoId == item.ProductoId && i.ColorId == item.ColorId);
                                productostock.Stock -= item.Cantidad;
                                db.Entry(productostock).State = EntityState.Modified;
                                db.DetallesVentaTMPs.Remove(item);
                            }


                            ViewBag.LocalidadId = new SelectList(db.Localidads, "LocalidadId", "Name", ventasViewModel.LocalidadId);
                            db.SaveChanges();

                            transaction.Commit();
                            return RedirectToAction("compraRealizada");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            ModelState.AddModelError(String.Empty, ex.Message);
                            return View(ventasViewModel);
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError(String.Empty, "No hay productos agregados.");
                    return View(ventasViewModel);
                }
            }
            ViewBag.LocalidadId = new SelectList(db.Localidads, "LocalidadId", "Name");
            return View(ventasViewModel);


        }

        [HttpPost]
        public ActionResult EstadoEntregado(VentasViewModel ventasView)
        {
            var venta = db.Ventas.Find(ventasView.VentaId);
            venta.Estado = "Entregado";
            db.Entry(venta).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult EstadoPendiente(VentasViewModel ventasView)
        {
            var venta = db.Ventas.Find(ventasView.VentaId);
            venta.Estado = "Pendiente";
            db.Entry(venta).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EstadoCancelado(VentasViewModel ventasView)
        {
            var venta = db.Ventas.Find(ventasView.VentaId);
            venta.Estado = "Cancelado";
            db.Entry(venta).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);

            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalidadId = new SelectList(db.Localidads, "LocalidadId", "Name", venta.LocalidadId);

            return View(venta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaId,NombreCliente,ApellidoCliente,LocalidadId,Direccion,Comentarios,Telefono,Correo,Fecha")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalidadId = new SelectList(db.Localidads, "LocalidadId", "Name", venta.LocalidadId);
            return View(venta);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Ventas.Find(id);
            //db.Ventas.Remove(venta);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            db.Ventas.Remove(venta);
            try
            {
                db.SaveChanges();
            }
            catch { }
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //[MultipleButton(Name = "action", Argument = "NuevaVenta")]
        public ActionResult NuevaVenta(int? page = null, Guid? cartId = null)
        {
            page = (page ?? 1);
            var productospl = db.Productos
              .Include(p => p.Categoria).OrderBy(p => p.Descripcion).ToPagedList((int)page, 12);
            //var productos = productospl.ToList();

            var productViewModels = new List<ProductoViewModel>();
            foreach (var product in productospl)
            {
                var colorIds = db.Inventarios.Where(i => i.ProductoId == product.ProductoId);
                var colors = db.Colors.Where(c => colorIds.Any(ci => ci.ColorId == c.ColorId)).Select(c => new SelectListItem { Text = c.Nombre, Value = c.ColorId.ToString() });
                product.ColorId = colors;// new SelectList(colors, "ColorId", "Nombre");
            };

            var details = new List<DetallesVentaTMP>();
            var cookie = Request.Cookies["your-cart-id"];

            if (cookie != null)
            {
                cartId = Guid.Parse(cookie?.Value);
                details = db.DetallesVentaTMPs.Where(d => d.CartId == cartId.Value).ToList();
            }
            else
            {
                cookie = new HttpCookie("your-cart-id");
            }

            var saleViewModel = new AgregarProdViewModel
            {
                DetallesVentas2 = details,
                AgregarProdPagedListVM = productospl,
            };
            if (cartId != null)
            {
                cookie.Value = cartId.ToString();// JsonConvert.SerializeObject(details.Select(d => new { DetallesVentaTmpId=d.DetallesVentaTmpId }));
                cookie.Expires = DateTime.Today.AddDays(1);
                HttpContext.Response.Cookies.Add(cookie);
            }
            ViewBag.LocalidadId = new SelectList(db.Localidads, "LocalidadId", "Name");
            return View(saleViewModel);
        }

        [HttpPost]
        public ActionResult NuevaVenta(AgregarProdViewModel newProduct)
        {

            if (ModelState.IsValid)
            {
                var cookie = Request.Cookies["your-cart-id"];
                var cartId = cookie != null ? Guid.Parse(cookie?.Value) : Guid.NewGuid();
                var product = db.Productos.Find(newProduct.ProductoId);
                var tmp = db.DetallesVentaTMPs.FirstOrDefault(sdt =>
                     sdt.ProductoId == newProduct.ProductoId && sdt.ColorId == newProduct.ColorId && sdt.CartId == cartId);

                if (tmp == null)
                {
                    tmp = new DetallesVentaTMP()
                    {
                        CartId = cartId,
                        Descripcion = product.Descripcion,
                        Precio = newProduct.Price,
                        ProductoId = newProduct.ProductoId,
                        Cantidad = newProduct.Cantidad,
                        ColorId = newProduct.ColorId,
                    };
                    db.DetallesVentaTMPs.Add(tmp);
                }
                else
                {
                    tmp.Cantidad += newProduct.Cantidad;
                    db.Entry(tmp).State = EntityState.Modified;
                }

                db.SaveChanges();

                return RedirectToAction("NuevaVenta", new { cartId = cartId });
            }
            return View(newProduct);
        }


        public ActionResult DeleteProduct(int id, int id2)
        {

            var cookie = Request.Cookies["your-cart-id"];

            if (cookie == null)
            {
                throw new ArgumentNullException("Cart cookie cannot be null!!");
            }

            var cartId = Guid.Parse(cookie?.Value);

            var product = db.Productos.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var tmp = db.DetallesVentaTMPs.FirstOrDefault(pdt => pdt.ProductoId == id && pdt.Color.ColorId == id2 && pdt.CartId == cartId);
            if (tmp != null)
            {
                if (tmp.Cantidad == 1)
                {
                    db.DetallesVentaTMPs.Remove(tmp);
                }
                else
                {
                    tmp.Cantidad = tmp.Cantidad - 1;
                    db.Entry(tmp).State = EntityState.Modified;
                }
                db.SaveChanges();
            }

            return RedirectToAction("NuevaVenta");
        }


        //public ActionResult ConfirmaVenta()
        //{
        //    var details = db.DetallesVentaTMPs.ToList();
        //    return View(details);
        //}

        public ActionResult compraRealizada()
        {

            return View();
        }

        [HttpGet]
        public ActionResult AlmostThere(VentasViewModel ventasVM)
        {
          
                var cookie = Request.Cookies["your-cart-id"];
                if (cookie == null)
                {
                    throw new ArgumentNullException("Cart cookie cannot be null!!");
                }
                var cartId = Guid.Parse(cookie?.Value);
                var newProduct = new VentasViewModel();
                var details = db.DetallesVentaTMPs.Where(pdt => pdt.CartId == cartId).ToList();
                newProduct.DetallesVentas2 = details;
            if (ModelState.IsValid)
            {

                //ViewBag.LocalidadId = new SelectList(db.Localidads, "LocalidadId", "Name");
                var localidad = db.Localidads.FirstOrDefault(pdt => pdt.LocalidadId == ventasVM.LocalidadId);
                Cliente datoscliente = new Cliente();
                datoscliente.NombreCliente = ventasVM.NombreCliente;
                datoscliente.ApellidoCliente = ventasVM.ApellidoCliente;
                datoscliente.LocalidadId = ventasVM.LocalidadId;
                datoscliente.Localidad = localidad;
                datoscliente.Direccion = ventasVM.Direccion;
                datoscliente.Telefono = ventasVM.Telefono;
                datoscliente.Comentarios = ventasVM.Comentarios;
                datoscliente.Correo = ventasVM.Correo;
                List<Cliente> listaclientes = new List<Cliente>();
                listaclientes.Add(datoscliente);
                newProduct.clienteList = listaclientes;
                if (SDK.AccessToken == null)
                {
                    MercadoPago.SDK.AccessToken = "TEST-7788000482666577-091415-7986e5879b06ba44a5641e081e562f2f-132111111";
                }
                Preference preference = new Preference();
                int n = 0;
                foreach (var item in details)
                {
                    int i = 1;

                    MercadoPago.DataStructures.Preference.Item pref = new MercadoPago.DataStructures.Preference.Item()
                    {
                        CategoryId = item.Product.CategoriaId,
                        Description = item.Descripcion,
                        //Id = $"{i}",
                        Title = item.Descripcion,
                        Quantity = (int)item.Cantidad,
                        CurrencyId = CurrencyId.ARS,
                        PictureUrl = item.Product.Image,

                    };

                    if (User.IsInRole("Mayorista"))
                    {
                        pref.UnitPrice = details[n].Product.PrecioMay;
                    }
                    else
                    {
                        pref.UnitPrice = details[n].Product.PrecioMin;
                    }
                    i++;
                    n = n + 1;
                    preference.Items.Add(pref);
                    preference.Save();
                };
                newProduct.Preference = preference;
                newProduct.PreferenciaId = preference.Id;
                return View(newProduct);
            }
     
            ViewBag.LocalidadId = new SelectList(db.Localidads, "LocalidadId", "Name");
            return View("Create", newProduct);

        }


    }
    }
