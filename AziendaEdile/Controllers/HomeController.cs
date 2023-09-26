using AziendaEdile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AziendaEdile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(DB.getAllDipendenti());
        }

        public ActionResult AddDipendente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDipendente(Dipendente dipendente)
        {
            if(ModelState.IsValid)
            {
                DB.AddEmployee(dipendente.Name,dipendente.Surname,dipendente.Address,dipendente.CF,dipendente.IsMarried,dipendente.NOfChildren,dipendente.Job);
                return RedirectToAction("Index");
            } else return View();
        }
        public ActionResult AddPayment(int id)
        {
            Pagamento pagamento = new Pagamento();
            pagamento.IdDipendente = id;
            return View(pagamento);
            
        }

        [HttpPost]
        public ActionResult AddPayment(Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                DB.AddPayment(pagamento.Date, pagamento.Amount, pagamento.Salary, pagamento.IdDipendente);
                return RedirectToAction("Index");
            }
            else return View();
        }
        public ActionResult ShowPayment(int id)
        {
            return View(DB.getAllPaymentByEmployee(id));
        }

        public ActionResult ShowAllPayment()
        {
            return View(DB.getAllPayments());
        }
    }
}