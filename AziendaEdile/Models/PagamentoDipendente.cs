using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AziendaEdile.Models
{
    public class PagamentoDipendente
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Job { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public bool Salary { get; set; }
    }
}