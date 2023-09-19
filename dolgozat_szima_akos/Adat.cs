using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat_szima_akos
{
    internal class Adat
    {
        public int taxi_id;
        public DateTime indulas;
        public string idotartam;
        public int tavolsag;
        public double vitelidij;
        public double borravalo;
        public string fizetes_modja;

        public Adat(string s)
        {
            string[] darabok = s.Split(';');
            this.taxi_id = Convert.ToInt32( darabok[0]);
            this.indulas = Convert.ToDateTime( darabok[1]);
            this.idotartam = darabok[2];
            this.vitelidij = Convert.ToDouble(darabok[3]);
            this.borravalo = Convert.ToDouble(darabok[4]);
            this.fizetes_modja = darabok[5];
        }

        public double MerfolValtas(double merfold)
        {
            double tavolsag = merfold * 1.6;
            return tavolsag;
        }
    }
}
