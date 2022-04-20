using mvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcTest.Controllers
{
    public class ProduitController : Controller
    {
        // GET: Produit
        Produit produit = new Produit();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProduitItems()
        {
            return View();
        }
    }
}