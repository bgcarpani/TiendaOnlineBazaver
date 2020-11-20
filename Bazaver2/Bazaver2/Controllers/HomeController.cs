using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Bazaver2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public JsonResult SendMailToUser()
        //{
        //    bool result = false;
        //    string sender = "sender", phone = "asd",  subject = "subject", message = "body";

        //    result = SendEmail("bauti.gonzalezc@hotmail.com", $"Bazaver Emailer:{subject}", $"Mensaje envíado desde la página web de Bazaver Lobos.</br>Envíado por: {sender}</br> Teléfono: {phone}</br>Mensaje: {message}");

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


        [HttpPost]
        public ActionResult SendEmail(string email, string name, string message, string phone, string subject)
        {
            try
            {
                string senderEmail = System. Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                subject = "Bazaver Automessage";
                string body = $"De: {name}, Email: {email}, Teléfono: {phone}, Asunto: {subject}, Mensaje: {message}";
                MailMessage mailMessage = new MailMessage(senderEmail, "bazaverlobos@gmail.com", subject, body);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);
                return View("Index");
            }
            catch (Exception ex)
            {
                return View();              
            }
        }


    }
}