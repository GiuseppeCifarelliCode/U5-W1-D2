using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AziendaEdile.Models
{
    public class Dipendente
    {
            public int Id;
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Address { get; set; }
            public string CF { get; set; }
            public bool IsMarried { get; set; }
            public int NOfChildren { get; set; }
            public string Job { get; set; }

            public Dipendente() { }
            public Dipendente(string name, string surname, string address, string cF, bool isMarried, int nOfChildren, string job)
            {
                Name = name;
                Surname = surname;
                Address = address;
                CF = cF;
                IsMarried = isMarried;
                NOfChildren = nOfChildren;
                Job = job;
            }
    }
}