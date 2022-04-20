using mvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace mvcTest.Controllers
{
    public class MembreController : Controller
    {
        // GET: Membre
        private Membre membre; 
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Inscription()
        {
            Session["liste"] = Request.Form["valeur1"];
            ViewBag.Message = "Inscription";
            return View();
        }
        
        public ActionResult Profile()
        {
            membre = new Membre();
            ViewBag.Message = "Bienvenue";
            if (Request.Form["pdw"] == Request.Form["pdwr"])
            {
                Session["nom"] = Request.Form["nom"];
                Session["prenom"] = Request.Form["prenom"];
                Session["email"] = Request.Form["email"];
                string value = "'" + Session["nom"] + "','" + Session["prenom"] + "','" + Session["email"] + "','" + Request.Form["pdw"] + "'";
                membre.addMembre("Stagiaire", "(`nomStag`, `prenomStag`, `emailStag`, `mdpStag`) VALUES (" + value + ")");
                /*membre.sendMail(Request.Form["email"], Session["liste"].ToString());*/
            }

            List<string> info = membre.login("Stagiaire", "`nomStag`, `prenomStag`, `emailStag`, `mdpStag`", "`emailStag` = '" + Request.Form["Username"] + "'");
            if (Request.Form["Username"] == info[2] && Request.Form["pass"] == info[3])
            {
                Session["nom"] = info[0];
                Session["prenom"] = info[1];
                Session["email"] = info[2];
                membre.sendMail(info[2], Session["liste"].ToString());
            }
            return View();
        }

        public ActionResult Connexion()
        {
            
            return View();
        }
    }
}