using CVRaul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CVRaul.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if ((DateTime.Now).Hour >= 0 && (DateTime.Now).Hour <= 11)
            {
                ViewBag.Saudacao = "Bom dia!";
            }
            else if ((DateTime.Now).Hour >= 12 && (DateTime.Now).Hour <= 17)
            {
                ViewBag.Saudacao = "Boa tarde!";
            }
            else if ((DateTime.Now).Hour >= 18)
            {
                ViewBag.Saudacao = "Boa noite!";
            }
            ActionExecutedContext reult = new ActionExecutedContext();

            Visitante visitante = Visitante.Existe();
            ViewBag.Visitante = visitante.Visitas;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contato contato)
        {
            //try
            //{
            //    ////parameters to send email
            //    //string ToEmail, FromOrSenderEmail = "contatoraulpontes@gmail.com", SubJect, Body;

            //    ////Reading values from form collection (Querystring) and assigning values to parameters
            //    //ToEmail = "guimao2@gmail.com";
            //    //SubJect = contato.Assunto;
            //    //Body = contato.Mensagem;

            //    ////Configuring webMail class to send emails
            //    //WebMail.SmtpServer = "smtp.gmail.com"; //gmail smtp server
            //    //WebMail.SmtpPort = 587; //gmail port to send emails
            //    //WebMail.SmtpUseDefaultCredentials = true;
            //    //WebMail.EnableSsl = true; //sending emails with secure protocol
            //    //WebMail.UserName = "contatoraulpontes@gmail.com";//EmailId used to send emails from application
            //    //WebMail.Password = "123Teste456";
            //    //WebMail.From = "contatoraulpontes@gmail.com"; //email sender email address.

            //    ////Sending email
            //    //WebMail.Send(to: ToEmail, subject: SubJect, body: Body, isBodyHtml: true);

            //    using (var message = new MailMessage(contato.Email, "guimao2@gmail.com"))
            //    {
            //        message.To.Add(new MailAddress("me@mydomain.com"));
            //        message.From = new MailAddress("contatoraulpontes@gmail.com");
            //        message.Subject = contato.Assunto;
            //        message.Body = contato.Mensagem;

            //        using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            //        {
            //            smtpClient.Send(message);
            //        }
            //    }
            //}
            //catch(Exception ex)
            //{
            //}
            try
            {
                MailMessage msz = new MailMessage();
                msz.From = new MailAddress(contato.Email);//Email which you are getting 
                                                     //from contact us page 
                msz.To.Add("guimao2@gmail.com");//Where mail will be sent 
                msz.Subject = contato.Assunto;
                msz.Body = $@"De: {contato.Nome}
E-mail de contato: {contato.Email} 
 {contato.Mensagem}";
                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential
                ("contatoraulpontes@gmail.com", "123Testando456");

                smtp.EnableSsl = true;

                smtp.Send(msz);

                ModelState.Clear();
                ViewBag.Sucesso = "Mensagem enviada com sucesso. Retornaremos o mais breve possivel.";
            }
            catch (Exception ex)
            {
                ModelState.Clear();
                ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
            }
            return View();
        }
    }
}