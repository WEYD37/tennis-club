using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeniszBeadando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeniszBeadando.Tests
{
    [TestClass()]
    public class TeniszklubTests
    {
        [TestMethod()]
        public void NapiBevetelTest()
        {
            Teniszklub klub = new Teniszklub();
            Klubtag klubtag1 = new Klubtag("John Doe");
            Klubtag klubtag2 = new Klubtag("Jane Smith");

            Teniszpalya palya1 = new Fuves(1, "Fuves", false);
            Teniszpalya palya2 = new Salakos(2, "Salakos", false);

            klub.AddTag(klubtag1);
            klub.AddTag(klubtag2);
            klub.AddPalya(palya1);
            klub.AddPalya(palya2);

            klubtag1.Foglalasok.Add(new Foglalas("John Doe", 1, Convert.ToDateTime("2023-06-26"), 1));
            klubtag2.Foglalasok.Add(new Foglalas("Jane Smith", 2, Convert.ToDateTime("2023-06-26"), 1));

            double expectedBevetel = palya1.Dij() + palya2.Dij();

            double actualBevetel = klub.NapiBevetel(Convert.ToDateTime("2023-06-26"));

            Assert.AreEqual(expectedBevetel, actualBevetel, "NapiBevetelTest: Failed");
        }

        [TestMethod()]
        public void HasznalatiDijTest()
        {
            Teniszklub klub = new Teniszklub();
            Klubtag klubtag1 = new Klubtag("John Doe");

            Teniszpalya palya1 = new Fuves(1, "Fuves", false);
            Teniszpalya palya2 = new Salakos(2, "Salakos", false);

            klub.AddTag(klubtag1);
            klub.AddPalya(palya1);
            klub.AddPalya(palya2);

            klubtag1.Foglalasok.Add(new Foglalas("John Doe", 1, Convert.ToDateTime("2023-06-26"), 1));
            klubtag1.Foglalasok.Add(new Foglalas("John Doe", 2, Convert.ToDateTime("2023-06-26"), 1));

            double expectedDij = palya1.Dij() + palya2.Dij();

            double actualDij = klub.HasznalatiDij("John Doe", Convert.ToDateTime("2023-06-26"));

            Assert.AreEqual(expectedDij, actualDij, "NapiBevetelTest: Failed");
        }

        [TestMethod()]
        public void ElerhetoPalyakTest()
        {
            Teniszklub klub = new Teniszklub();
            Fuves palya1 = new Fuves(1, "Fuves", false);
            klub.AddPalya(palya1);
            Salakos palya2 = new Salakos(2, "Salakos", true);
            klub.AddPalya(palya2);
            Muanyag palya3 = new Muanyag(3, "Muanyag", false);
            klub.AddPalya(palya3);

            Klubtag tag1 = new Klubtag("John");
            Klubtag tag2 = new Klubtag("Johnny");
            klub.AddTag(tag1);
            klub.AddTag(tag2);

            tag1.Foglalas("John", 1, Convert.ToDateTime("2023-06-26"), 10);
            tag2.Foglalas("Johnny", 2, Convert.ToDateTime("2023-06-26"), 10);

            List<int> elerhetoPalyak = klub.ElerhetoPalyak(Convert.ToDateTime("2023-06-26"), 10, "Salakos");

            Assert.AreEqual(0, elerhetoPalyak.Count);
        }

        [TestMethod()]
        public void FoglaltPalyakTest()
        {
            Teniszklub klub = new Teniszklub();

            Fuves palya1 = new Fuves(1, "Fuves", false);
            klub.AddPalya(palya1);
            Salakos palya2 = new Salakos(2, "Salakos", true);
            klub.AddPalya(palya2);
            Muanyag palya3 = new Muanyag(3, "Muanyag", false);
            klub.AddPalya(palya3);

            Klubtag tag1 = new Klubtag("John");
            Klubtag tag2 = new Klubtag("Johnny");

            klub.AddTag(tag1);
            klub.AddTag(tag2);

            tag1.Foglalas("John", 1, Convert.ToDateTime("2023-06-26"), 10);
            tag1.Foglalas("Johnny", 1, Convert.ToDateTime("2023-06-26"), 10);

            List<Tuple<int, int>> foglaltPalyak = klub.FoglaltPalyak("Johnny", Convert.ToDateTime("2023-06-26"));

            Assert.AreEqual(0, foglaltPalyak.Count);
        }
    }
}
