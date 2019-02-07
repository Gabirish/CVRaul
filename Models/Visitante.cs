using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CVRaul.Models
{
     public class Visitante
    {
        public int ID { get; set; }
        public string Ip { get; private set; }
        public int Visitas { get; private set; }


        CVRaulDBContext db = new CVRaulDBContext();

        public Visitante()
        {
            Ip = PegaIp();
            Visitas = 1;

            //db.Visitantes.Add(this);
            //db.SaveChanges();
        }

        public static Visitante Existe()
        {
            CVRaulDBContext db = new CVRaulDBContext();
            string ip = PegaIp();
            Visitante visitante = db.Visitantes.FirstOrDefault(v => v.Ip == ip);
           if (visitante != null)
            {
                visitante.Visitas++;
                db.SaveChanges();
                return visitante;
            }
            else
            {
              visitante = new Visitante();
                db.Visitantes.Add(visitante);
                db.SaveChanges();
            }
            return visitante;
        }

        protected static string PegaIp()
        {
            string VisitorsIPAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
              Regex regex = new Regex("\\d+\\.\\d+\\.\\d+\\.\\d+");
              Match match = regex.Match(VisitorsIPAddr);

            if (match.Success)
            {
                VisitorsIPAddr = match.Value;
            }

            return VisitorsIPAddr;
        }

        public class CVRaulDBContext : DbContext
        {
            public DbSet<Visitante> Visitantes { get; set; }
            public CVRaulDBContext() : base("CVRaul")
            {
            }

        }


    }
}