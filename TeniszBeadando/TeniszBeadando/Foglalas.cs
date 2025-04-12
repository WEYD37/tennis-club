using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeniszBeadando
{
    public class Foglalas
    {
        public string Nev { get; set; }
        public int Sorszam { get; set; }
        public DateTime Datum { get; set; }
        public int Ora { get; set; }

        public Foglalas(string nev, int sorszam, DateTime datum, int ora)
        {
            Nev = nev;
            Sorszam = sorszam;
            Datum = datum;
            Ora = ora;
        }
    }
}
