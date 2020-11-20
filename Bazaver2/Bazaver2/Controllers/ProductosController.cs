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


namespace Bazaver2.Controllers
{
  
    public class ProductosController : Controller
    {
        private Bazaver2DbContext db = new Bazaver2DbContext();

        public object CombosHelper { get; private set; }

        // GET: Productos
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var productos = db.Inventarios
                .Include(p => p.Productos).Include(p => p.Productos.Categoria)
                .Include(p => p.Color).OrderBy(p => p.Productos.Descripcion).ToList();
            var inview = new InventarioViewModel()
            {
                InventarioList = productos,
            };
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion");
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre");
            return View(inview);
        }

        // GET: Productos/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ColorProducto()
        {
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion");
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult ColorProducto(ColorProductoViewModel productoViewModel)
        {

            if (ModelState.IsValid)
            {

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        try
                        {
                            var inventario = new Inventario()
                            {
                                ProductoId = productoViewModel.ProductoId,
                                ColorId = productoViewModel.ColorId,
                                Stock = productoViewModel.Stock,
                            };
                            db.Inventarios.Add(inventario);
                            db.SaveChanges();
                            transaction.Commit();
                            return RedirectToAction("Index");
                        }
                        catch (Exception ex)
                        {
                            if (ex.InnerException != null &&
                                       ex.InnerException.InnerException != null &&
                                       ex.InnerException.InnerException.Message.Contains("IX_Productos_Colors"))
                            {
                                ModelState.AddModelError(String.Empty, "El producto ya existe");
                            }
                            else
                            {
                                ModelState.AddModelError(String.Empty, ex.Message);
                            }
                            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion");
                            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre");
                            return View(productoViewModel);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError(String.Empty, ex.Message);
                        ViewBag.CategoriaId = new SelectList(db.Productos, "ProductoId", "Descripcion");
                        ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre");
                        return View(productoViewModel);
                    }
                }
            }
            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoId", "Descripcion");
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre");
            return View(productoViewModel);
        }


        // GET: Productos/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descripcion");
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre");
            return View();
        }

   
        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(ProductoViewModel productoViewModel)
        {
    
            if (ModelState.IsValid)
            {
                using (var transaction = db.Database.BeginTransaction())
                {

                    try
                    {
                        var product = ToProduct(productoViewModel);
                        try
                        {
                            
                            db.Productos.Add(product);
                            db.SaveChanges();
                            var inventario = new Inventario()
                            {
                                ProductoId = product.ProductoId,
                                ColorId = productoViewModel.ColorId,
                                Stock= productoViewModel.Stock,
                            };
                            db.Inventarios.Add(inventario);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            if (ex.InnerException != null &&
                                ex.InnerException.InnerException != null &&
                                ex.InnerException.InnerException.Message.Contains("IX_Productos_Codigo"))
                            {
                                ModelState.AddModelError(String.Empty, "El producto ya existe");
                            }
                            else
                            {
                                ModelState.AddModelError(String.Empty, ex.Message);
                            }
                            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descripcion");
                            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre"); 
                            return View(productoViewModel);
                        }
                        if (productoViewModel.ImageFile != null)
                        {
                            var folder = "~/Content/Images";
                            var file = $"{product.ProductoId}.jpg";
                            var response = FileHelper.UploadPhoto(productoViewModel.ImageFile, folder, file);

                            if (response)
                            {
                                var pic = $"{folder}/{file}";
                                product.Image = pic;
                                db.Entry(product).State = EntityState.Modified;
                                db.SaveChanges();

                            }
                        }
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError(String.Empty, ex.Message);
                        ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descripcion");
                        ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre");
                        return View(productoViewModel);
                    }
                }

            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descripcion");
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre");
            return View(productoViewModel);

        }
        private Productos ToProduct(ProductoViewModel productViewModel)
        {

            return new Productos()
            {
                ProductoId = productViewModel.ProductoId,
                Descripcion = productViewModel.Descripcion,
                CategoriaId = productViewModel.CategoriaId,
                //ColorId = productViewModel.ColorId,               
                PrecioMin = productViewModel.PrecioMin,
                PrecioMay = productViewModel.PrecioMay,
                Image = productViewModel.Image,                
                //Stock = productViewModel.Stock,
                Codigo=productViewModel.Codigo,
            };
        }

        // GET: Productos/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            //Inventario inventario = db.Inventarios.FirstOrDefault(p=>p.ProductoId == productos.ProductoId);
            //var inventVM = new InventarioViewModel
            //{
            //    CategoriaId = inventario.Productos.CategoriaId,
            //    Codigo = inventario.Productos.Codigo,
            //    Stock = inventario.Stock,
            //    ProductoId = inventario.Productos.ProductoId,
            //    PrecioMin = inventario.Productos.PrecioMin,
            //    PrecioMay = inventario.Productos.PrecioMay,
            //    Image = inventario.Productos.Image,
            //    Descripcion =inventario.Productos.Descripcion,
            //    ColorId = inventario.Color.ColorId,
                            
            //};
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descripcion", productos.CategoriaId);
            //ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre", productos.ColorId);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ProductoId,Descripcion,CategoriaId,PrecioMin,PrecioMay,Image,Codigo")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descripcion", productos.CategoriaId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre", productos.ColorId);
            return View(productos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult EditStock([Bind(Include = "InventarioId,ProductoId,ColorId,Stock")] Inventario inven)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inven).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descripcion", inven.Productos.CategoriaId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Nombre", inven.ColorId);
            return View(inven);
        }
        // GET: Productos/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventarios.FirstOrDefault(p=>p.ColorId == id2 && p.ProductoId==id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            var incView = new InventarioViewModel();
            incView.CategoriaId=inventario.Productos.CategoriaId;
            incView.Codigo = inventario.Productos.Codigo;
            incView.ColorId = inventario.ColorId;
            incView.Descripcion = inventario.Productos.Descripcion;
            incView.Image = inventario.Productos.Image;
            incView.PrecioMay = inventario.Productos.PrecioMay;
            incView.PrecioMin = inventario.Productos.PrecioMin;
            incView.Stock = inventario.Stock;
            incView.ProductoId = inventario.ProductoId;  
            return View(incView);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            Inventario inventario = db.Inventarios.FirstOrDefault(p => p.ColorId == id2 && p.ProductoId == id);
            db.Inventarios.Remove(inventario);
            db.SaveChanges();
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
    }
}
