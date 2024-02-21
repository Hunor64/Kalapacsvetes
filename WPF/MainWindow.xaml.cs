using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Pars2012GUI
{
    public partial class MainWindow : Window
    {
        List<List<string>> elemek = new List<List<string>>();

        public MainWindow()
        {
            InitializeComponent();
            AdatokBetoltese();
            VersenyzoAdatainakMegjelenitese("Pars Krisztián");
        }

        public void AdatokBetoltese()
        {
            var elemekSora = File.ReadAllLines("Selejtezo2012.txt");
            foreach (var sor in elemekSora)
            {
                elemek.Add(sor.Split(';').ToList());
                cmbVersenyzok.Items.Add(sor.Split(';')[1]);
            }
            elemek.RemoveAt(0);
        }

        private void cmbVersenyzok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbVersenyzok.SelectedItem != null)
            {
                string kivalasztottVersenyzo = cmbVersenyzok.SelectedItem.ToString();
                VersenyzoAdatainakMegjelenitese(kivalasztottVersenyzo);
            }
        }

        private void VersenyzoAdatainakMegjelenitese(string versenyzoNeve)
        {
            var versenyzoAdatai = elemek.FirstOrDefault(a => a.Contains(versenyzoNeve));
            if (versenyzoAdatai != null)
            {
                txbCsoport.Text = "Csoport: " + versenyzoAdatai[0];
                txbNemzet.Text = "Nemzet: " + versenyzoAdatai[2];
                txbNemzetKod.Text = "Nemzet kód: " + versenyzoAdatai[3];
                txbSorozat.Text = "Sorozat: " + versenyzoAdatai[4];
                txbEredmeny.Text = "Eredmény: " + versenyzoAdatai[5];

                string orszagKod = versenyzoAdatai[3];
                string zaszloUtvonal = $"Images\\{orszagKod}.png";
                if (File.Exists(zaszloUtvonal))
                {
                    imgZaszlo.Source = new BitmapImage(new Uri(zaszloUtvonal));
                }
                else
                {
                    MessageBox.Show(orszagKod + " zászlója nem található");
                }
            }
        }
    }
}
