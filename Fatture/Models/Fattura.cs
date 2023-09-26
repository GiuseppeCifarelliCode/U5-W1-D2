using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fatture.Models
{
    public class Fattura
    {
        [Required(ErrorMessage ="Inserisci il N. Fattura")]
        public int nFattura { get; set; }

        public DateTime Data { get; set; }

        [Required(ErrorMessage ="Inserisci il Nominativo Cliente")]
        public string Nominativo { get; set; }
        [Required(ErrorMessage ="Inserisci un Importo")]
        public double Importo { get; set; }

        public static List<Fattura> listaFatture = new List<Fattura>();

        public Fattura() { }
        public Fattura(int nFattura, DateTime data, string nominativo, double importo)
        {
            this.nFattura = nFattura;
            Data = data;
            Nominativo = nominativo;
            Importo = importo;
        }
        
        public static double getTotFatture()
        {
            double tot = 0;
            foreach(Fattura fattura in listaFatture)
            {
                tot += fattura.Importo;
            }
            return tot;
            
        }
    }
}