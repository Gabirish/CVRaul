using CVRaul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using static CVRaul.Models.Visitante;

namespace CVRaul.Controllers
{
    public class HomeController : Controller
    {

        CVRaulDBContext db = new CVRaulDBContext();

        public ActionResult Index()
        {

            //if ((datetime.now).hour >= 0 && (datetime.now).hour <= 11)
            //{
            //    viewbag.saudacao = "bom dia!";
            //}
            //else if ((datetime.now).hour >= 12 && (datetime.now).hour <= 17)
            //{
            //    viewbag.saudacao = "boa tarde!";
            //}
            //else if ((datetime.now).hour >= 18)
            //{
            //    viewbag.saudacao = "boa noite!";
            //}

            ViewBag.Saudacao = $"{DateTime.Now.TimeOfDay}";

            //ActionExecutedContext reult = new ActionExecutedContext();

            Visitante visitante = Existe();

            string numeroDeVisitas = "Você visitou minha pagina";
            if (visitante.Visitas == 1)
            {
                numeroDeVisitas += $" {visitante.Visitas} vez!";
            } 
            else{ numeroDeVisitas += $" {visitante.Visitas} vezes!"; }

            ViewBag.Visitante = numeroDeVisitas;
            // List<Visitante> lista = db.Visitantes.ToList();
            ViewBag.Lista = db.Visitantes.ToList(); ;
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
            
             string teste = Email.Email.EnviarEmail(contato.Email, contato.Assunto, contato.Nome, contato.Mensagem);
            if (teste != null)
            {
                ViewBag.Sucesso = $" Estamos com dificuldades no momento. Tente novamente mais tarde. Erro:{teste}";
            }
            else
            {
                ModelState.Clear();
                ViewBag.Sucesso = "Mensagem enviada com sucesso. Retornaremos o mais breve possivel.";
            }


            
            return View();
        }
    }
}