using Fatture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatture.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Fattura.listaFatture);
        }

        public ActionResult AddFatture()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFatture(Fattura fattura)
        {
            if(ModelState.IsValid)
            {
                Fattura.listaFatture.Add(fattura);
                return RedirectToAction("Index");
            } else return View();
        }

        public ActionResult _ListaFatture()
        {
            return PartialView(Fattura.listaFatture);
        }
    }
}