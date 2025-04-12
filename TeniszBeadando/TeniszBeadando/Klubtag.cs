using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeniszBeadando
{
    public class Klubtag
    {
        public string Nev { get; set; }
        public List<Foglalas> Foglalasok { get; set; }

        public Klubtag(string nev)
        {
            Nev = nev;
            Foglalasok = new List<Foglalas>();
        }

        public void Foglalas(string nev, int sorszam, DateTime datum, int ora)
        {
            Foglalas foglalas = new Foglalas(Nev, sorszam, datum, ora);
            Foglalas existingFoglalas = Foglalasok.FirstOrDefault(f => f.Sorszam == sorszam && f.Datum == datum && f.Ora == ora);

            if (existingFoglalas == null)
            {
                Foglalasok.Add(foglalas);
            }
        }

        public void FoglalasTorles(Foglalas foglalas)
        {
            Foglalasok.Remove(foglalas);
        }
    }
}
