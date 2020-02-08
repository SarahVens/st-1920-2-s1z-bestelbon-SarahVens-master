using System;
using System.Collections.Generic;
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

namespace Bestelbon.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variabele
        int aantalStuks;
        double stukprijsExclBtw;
        double stukprijsInclBtw;
        int aantalBesteldeStuks=0;
        double totalePrijs = 0;
 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstBtw.Items.Add("6");
            lstBtw.Items.Add("21");
            lstBtw.SelectedIndex = 1;
            txtArtikelNaam.Text = "Spatbord";
            txtPrijsExcl.Text = "5,45";
            aantalStuks = 1;
            lblAantal.Content = aantalStuks.ToString();
            btnBestel.IsEnabled = false;
            btnMin1.IsEnabled = false;
            btnPlus1.IsEnabled = false;

        }

        private void txtPrijsExcl_LostFocus(object sender, RoutedEventArgs e)
        {
            stukprijsExclBtw = Convert.ToDouble(txtPrijsExcl.Text);

        }

        private void lstBtw_GotFocus(object sender, RoutedEventArgs e)
        {
            double btw = Convert.ToDouble(lstBtw.SelectedItem.ToString());
            double btwBerekend = (stukprijsExclBtw/100)*btw;
            stukprijsInclBtw = stukprijsExclBtw + btwBerekend;
            lblPrijsIncl.Content = Convert.ToString(stukprijsInclBtw);
            btnBestel.IsEnabled = true;
            btnMin1.IsEnabled = true;
            btnPlus1.IsEnabled = true;
        }

        private void btnPlus1_Click(object sender, RoutedEventArgs e)
        {
            if (aantalStuks < 0) aantalStuks = 0;
            aantalStuks = aantalStuks + 1;
            lblAantal.Content = aantalStuks.ToString();
        }

        private void btnMin1_Click(object sender, RoutedEventArgs e)
        {
            aantalStuks = aantalStuks - 1;
            if (aantalStuks < 0) aantalStuks = 0;
            else
                lblAantal.Content = aantalStuks.ToString();
        }

        private void lstBtw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double btw = Convert.ToDouble(lstBtw.SelectedItem.ToString());
            double btwBerekend = (stukprijsExclBtw / 100) * btw;
            stukprijsInclBtw = stukprijsExclBtw + btwBerekend;
            lblPrijsIncl.Content = Convert.ToString(stukprijsInclBtw);

        }

        private void btnBestel_Click(object sender, RoutedEventArgs e)
        {
            //artikel lijst
            string artikelNaam = txtArtikelNaam.Text;
            lblBesteldeArtikelen.Content += artikelNaam + Environment.NewLine;

            //Prijs per artikel
            double prijsPerArtikel;
            prijsPerArtikel = stukprijsInclBtw * aantalStuks;
            tbkBestelling.Text += Convert.ToString(aantalStuks) + " X " + Convert.ToString(stukprijsInclBtw) + " = " + Convert.ToString(prijsPerArtikel) + Environment.NewLine;

            //totale prijs

            totalePrijs += totalePrijs + prijsPerArtikel;
            lblTotaalPrijs.Content = Convert.ToString(totalePrijs);

            // totaal aantal
            aantalBesteldeStuks = aantalBesteldeStuks + aantalStuks;
            lblTotaalAantal.Content = Convert.ToString(aantalBesteldeStuks);

            //clear fields
            txtArtikelNaam.Text = "";
            txtPrijsExcl.Text = "1";
            lblAantal.Content = Convert.ToString(aantalStuks);
            lblPrijsIncl.Content = "";
            btnPlus1.IsEnabled = false;
            btnMin1.IsEnabled = false;
            btnBestel.IsEnabled = false;
            lstBtw.Focusable = false;
            txtArtikelNaam.Focus();
            aantalStuks = 0;
        
        }

    }
}
