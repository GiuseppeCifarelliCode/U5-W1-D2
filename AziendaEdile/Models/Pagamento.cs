using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AziendaEdile.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public bool Salary { get; set; }

        public int IdDipendente { get; set; }

        public Pagamento() { }

        public Pagamento(Dipendente dipendente) {
            IdDipendente = dipendente.Id;
        }
        public Pagamento(DateTime date, double amount, bool salary, int idDipendente)
        {
            Date = date;
            Amount = amount;
            Salary = salary;
            IdDipendente = idDipendente;
        }
    }
}