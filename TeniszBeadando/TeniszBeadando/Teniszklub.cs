using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeniszBeadando
{
    public class Teniszklub
    {
        public List<Klubtag> tagok { get; set; }
        public List<Teniszpalya> palyak { get; set; }

        public Teniszklub()
        {
            tagok = new List<Klubtag>();
            palyak = new List<Teniszpalya>();
        }

        public void AddTag(Klubtag tag)
        {
            tagok.Add(tag);
        }

        public void RemTag(Klubtag tag)
        {
            if (tag != null)
            {
                tagok.Remove(tag);
            }
        }

        public void AddPalya(Teniszpalya palya)
        {
            palyak.Add(palya);
        }

        public void RemPalya(Teniszpalya palya)
        {
            if (palya != null)
            {
                palyak.Remove(palya);
            }
        }

        public double HasznalatiDij(string nev, DateTime datum)
        {
            double dij = 0;
            foreach (Klubtag klubtag in tagok)
            {
                if (klubtag.Nev == nev)
                {
                    foreach (Foglalas foglalas in klubtag.Foglalasok)
                    {
                        Console.WriteLine();
                        if (foglalas.Datum == datum)
                        {
                            double oradij = 0;
                            for (int i = 0; i < palyak.Count(); i++)
                            {
                                if (palyak[i].Sorszam == foglalas.Sorszam)
                                {
                                    oradij = palyak[i].Dij();
                                    break;
                                }
                            }
                            dij += oradij;
                        }
                    }
                }
            }
            return dij;
        }

        public double NapiBevetel(DateTime datum)
        {
            double bevetel = 0;
            foreach (Klubtag klubtag in tagok)
            {
                foreach (Foglalas foglalas in klubtag.Foglalasok)
                {
                    if (foglalas.Datum == datum)
                    {
                        double oradij = 0;
                        for (int i = 0; i < palyak.Count(); i++)
                        {
                            if (palyak[i].Sorszam == foglalas.Sorszam)
                            {
                                oradij = palyak[i].Dij();
                                break;
                            }
                        }
                        bevetel += oradij;
                    }
                }
            }
            return bevetel;
        }

        public List<int> ElerhetoPalyak(DateTime datum, int ora, string boritas)
        {
            List<int> elerhetoPalyak = new List<int>();
            foreach (Teniszpalya palya in palyak)
            {
                if (palya.Boritas == boritas)
                {
                    bool elerheto = true;
                    foreach (Klubtag klubtag in tagok)
                    {
                        foreach (Foglalas foglalas in klubtag.Foglalasok)
                        {
                            if (foglalas.Datum == datum && foglalas.Ora == ora && foglalas.Sorszam == palya.Sorszam)
                            {
                                elerheto = false;
                                break;
                            }
                        }
                    }
                    if (elerheto)
                    {
                        elerhetoPalyak.Add(palya.Sorszam);
                    }
                }
            }
            var eList = elerhetoPalyak.Distinct().ToList();
            return eList;
        }

        public List<Tuple<int,int>> FoglaltPalyak(string nev, DateTime datum)
        {
            List<Tuple<int, int>> foglaltPalyak = new List<Tuple<int, int>>();
            foreach (Klubtag klubtag in tagok)
            {
                foreach (Foglalas foglalas in klubtag.Foglalasok)
                {
                    if (foglalas.Nev == nev && foglalas.Datum == datum)
                    {
                        foglaltPalyak.Add(new Tuple<int, int>(foglalas.Sorszam, foglalas.Ora));
                    }
                }
            }
            return foglaltPalyak;
        }
    }
}
