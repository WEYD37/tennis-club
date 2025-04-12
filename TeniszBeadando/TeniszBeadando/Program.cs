using System;
using System.Reflection.PortableExecutable;
using TeniszBeadando;
using TextFile;
using System.Linq;

namespace TeniszBeadando
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Teniszklub teniszklub = new Teniszklub();

            TextFileReader tagReader = new TextFileReader("inp1.txt");
            string str1 = tagReader.ReadLine();
            while (tagReader.ReadLine(out str1))
            {
                teniszklub.AddTag(new Klubtag(str1));
            }

            TextFileReader palyaReader = new TextFileReader("inp2.txt");
            string str2 = palyaReader.ReadLine();
            while (palyaReader.ReadLine(out str2))
            {
                string[] tokens = str2.Split(new char[] { ' ' });
                Teniszpalya? palya = null;
                switch (tokens[1])
                {
                    case "Fuves":
                        palya = new Fuves(Convert.ToInt32(tokens[0]), tokens[1], (tokens[2] == "Fedett") ? true : false);
                        teniszklub.AddPalya(palya);
                        break;
                    case "Salakos":
                        palya = new Salakos(Convert.ToInt32(tokens[0]), tokens[1], (tokens[2] == "Fedett") ? true : false);
                        teniszklub.AddPalya(palya);
                        break;
                    case "Muanyag":
                        palya = new Muanyag(Convert.ToInt32(tokens[0]), tokens[1], (tokens[2] == "Fedett") ? true : false);
                        teniszklub.AddPalya(palya);
                        break;
                    default:
                        break;
                }
            }

            TextFileReader foglalasReader = new TextFileReader("inp3.txt");
            string str3 = foglalasReader.ReadLine();
            while (foglalasReader.ReadLine(out str3))
            {
                string[] tokens = str3.Split(new char[] { '\t' });

                foreach (Klubtag tag in teniszklub.tagok)
                {
                    if (tag.Nev == tokens[1])
                    {
                        if (tokens[0] == "Foglalas:")
                        {
                            tag.Foglalas(tokens[1], Convert.ToInt32(tokens[2]), Convert.ToDateTime(tokens[3]), Convert.ToInt32(tokens[4]));
                        }
                        else
                        {
                            tag.FoglalasTorles(new Foglalas(tokens[1], Convert.ToInt32(tokens[2]), Convert.ToDateTime(tokens[3]), Convert.ToInt32(tokens[4])));
                        }
                    }
                }
            }

            Console.WriteLine(teniszklub.HasznalatiDij("John Doe", Convert.ToDateTime("2023 - 06 - 22")));

            Console.WriteLine(teniszklub.NapiBevetel(Convert.ToDateTime("2023 - 06 - 22")));

            List<int> elerheto = teniszklub.ElerhetoPalyak(Convert.ToDateTime("2023 - 06 - 23"), 12, "Muanyag");

            foreach (var i in elerheto)
            {
                Console.WriteLine(i);
            }

            List<Tuple<int, int>> foglaltPalyak = teniszklub.FoglaltPalyak("Mark Johnson", Convert.ToDateTime("2023 - 06 - 23"));

            foreach (var tuple in foglaltPalyak)
            {
                Console.WriteLine("{0} - {1}", tuple.Item1, tuple.Item2);
            }

            foreach (var i in teniszklub.tagok)
            {
                foreach (var j in i.Foglalasok)
                {
                    Console.WriteLine(j.Nev + " " + j.Sorszam + " " + j.Datum + " " + j.Ora);
                }
            }
        }
    }
}