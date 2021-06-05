using Functions;
using KonkretneKlase;
using ResidentExecutor;
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

namespace Resident_Executor
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Caller caller = new Caller();
            caller.Call();
            Update();

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        


        private void izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dodajnp_Click(object sender, RoutedEventArgs e)
        {
            DodavanjePodrucja dp = new DodavanjePodrucja(this); //SALJEM OBJEKAT MAINWINDOWA, KONKRETNO OVAJ(this) DA BIH U DODAVANJANJEPODRUCIJA
            dp.Show();                                          // PROZORU NA NJEMU KONKRETNO MOGAO POZVATI UPDATE, METODA ISPOD NAPISANA

        }

        private void prikazi_Click(object sender, RoutedEventArgs e)
        {
            Prikaz p = new Prikaz();
            p.Show();
        }

        
        private void upisi_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(potrosnja_tb.Text, out double hh))
            {
                greskaPotrosnja.Content = "";
                potrosnja_tb.ClearValue(Border.BorderBrushProperty);

                if (hh > 0)
                {
                    greskaPotrosnja.Content = "";
                    potrosnja_tb.ClearValue(Border.BorderBrushProperty);

                    if (combo_sifre.SelectedItem != null)
                    {
                        greskaId.Content = "";
                        combo_sifre.ClearValue(Border.BorderBrushProperty);

                        Izmereno iz = new Izmereno();

                        iz.id = new Posrednik().BrojIzmerenih() + 1;
                        iz.sifrapd = combo_sifre.SelectedItem.ToString();
                        iz.nazivpd = new Posrednik().VratiNaziv(combo_sifre.SelectedItem.ToString());
                        iz.vrednost = Double.Parse(potrosnja_tb.Text);
                        iz.datumvreme = DateTime.Now;

                        new Posrednik().UpisiIzmereno(iz);

                        MessageBox.Show("Upisano u sistem!", "USPEH", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        greskaId.Content = "Niste izabrali podrucje!";
                        combo_sifre.BorderBrush = Brushes.Red;
                    }

                }

                else
                {
                    greskaPotrosnja.Content = "Potrosnja mora biti veca od 0!";
                    potrosnja_tb.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                greskaPotrosnja.Content = "Potrosnja mora biti broj!";
                potrosnja_tb.BorderBrush = Brushes.Red;
            }
        }

        public void Update()
        {
            List<string> lista = new Posrednik().VratiListu();

            combo_sifre.Items.Clear();
            foreach (string s in lista)
            {
                combo_sifre.Items.Add(s);
            }
        }


    }
}
