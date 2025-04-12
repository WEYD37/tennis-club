using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeniszBeadando
{
    public abstract class Teniszpalya
    {
        public int Sorszam;
        public string Boritas;
        public bool Fedett;

        public Teniszpalya(int sorszam, string boritas, bool fedett)
        {
            Sorszam = sorszam;
            Boritas = boritas;
            Fedett = fedett;
        }

        public virtual double Dij()
        { return 0; }
    }

    public class Fuves : Teniszpalya
    {
        public Fuves(int sorszam, string boritas, bool fedett)
            : base(sorszam, boritas, fedett)
        {

        }
        public override double Dij()
        {
            double sator = 1;
            if (Fedett)
            {
                sator = 1.2;
            }
            return 5000 * sator;
        }
    }

    public class Salakos : Teniszpalya
    {
        public Salakos(int sorszam, string boritas, bool fedett)
            : base(sorszam, boritas, fedett)
        {

        }
        public override double Dij()
        {
            double sator = 1;
            if (Fedett)
            {
                sator = 1.2;
            }
            return 3000 * sator;
        }
    }

    public class Muanyag : Teniszpalya
    {
        public Muanyag(int sorszam, string boritas, bool fedett)
            : base(sorszam, boritas, fedett)
        {

        }
        public override double Dij()
        {
            double sator = 1;
            if (Fedett)
            {
                sator = 1.2;
            }
            return 2000 * sator;
        }
    }
}
