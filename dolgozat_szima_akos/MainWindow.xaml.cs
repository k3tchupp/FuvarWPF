using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dolgozat_szima_akos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Adat> lista = new List<Adat>();

            using(StreamReader sr = new StreamReader("fuvar.csv"))
            {
                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    Adat s = new Adat(sor);
                    lista.Add(s);
                }
            }
            // 3.
            MessageBox.Show(Convert.ToString(lista.Count));

            // 4.
            Adat azonositoju = lista.Where(x => x.taxi_id == 6185).First();

            double bevetel = azonositoju.vitelidij + azonositoju.borravalo;
            int fuvarok_szama = lista.Where(x => x.taxi_id == 6185).Count();

            MessageBox.Show(Convert.ToString(bevetel), Convert.ToString(fuvarok_szama) );

            // 5.
            foreach (var item in lista.GroupBy(x=>x.fizetes_modja))
            {
                MessageBox.Show(item.Key, Convert.ToString( item.Count()));
            }


            // 6.

            double osszesen = lista.Sum(x => x.MerfolValtas(x.tavolsag));
            MessageBox.Show(Convert.ToString(osszesen));

            // 7.

            Adat leghosszabb = lista.OrderBy(x => x.idotartam).First();
            MessageBox.Show(Convert.ToString(leghosszabb.taxi_id, leghosszabb.indulas, leghosszabb.idotartam, leghosszabb.tavolsag, leghosszabb.vitelidij, leghosszabb.borravalo, leghosszabb.fizetes_modja));

            // 8.

            /*foreach (var item in lista)
            {
                if (Convert.ToInt32( item.idotartam) > 0 && item.vitelidij > 0 && item.tavolsag == 0)
                {
                    
                }
            }*/

            //File.WriteAllText("hibak.txt", )

        }
    }
}
