using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Pars2012GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<List<string>> elemek = new List<List<string>>();

        public MainWindow()
        {
            InitializeComponent();
            LoadPeople();
        }

        public void LoadPeople()
        {
            var elements = File.ReadAllLines("Selejtezo2012.txt");
            foreach (var element in elements)
            {
                elemek.Add(element.Split(';').ToList());
                cmbVersenyzok.Items.Add(element.Split(';')[1]);
            }
            elemek.RemoveAt(0);
        }

        private void cmbVersenyzok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbVersenyzok.SelectedIndex >= 0)
            {
                int index = cmbVersenyzok.SelectedIndex;

                txbCsoport.Text = elemek[index][0];
                txbNemzet.Text = elemek[index][2];
                txbNemzetKod.Text = elemek[index][3];
                txbSorozat.Text = elemek[index][4];
                txbEredmeny.Text = elemek[index][5];

                string nemzetKod = txbNemzetKod.Text;
                imgZaszlo.Source = new BitmapImage(new Uri($"/Images/{nemzetKod}.png"));
            }
        }
    }
}
