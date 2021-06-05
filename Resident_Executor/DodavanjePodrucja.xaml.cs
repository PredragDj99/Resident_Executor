using Functions;
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
using System.Windows.Shapes;

namespace Resident_Executor
{
    /// <summary>
    /// Interaction logic for DodavanjePodrucja.xaml
    /// </summary>
    public partial class DodavanjePodrucja : Window
    {
        private MainWindow win;  // PROMENLJIVA KOJA SE VIDI U CELOJ KALSI

        public DodavanjePodrucja(MainWindow win)    //MAINWINDOW OBJEKAT KOJI PRIMI IZ ISTOIMENE KLASE
        {
            InitializeComponent();
            this.win = win;     //DODELI JE PUBLIC OBJEKTU WIN DA SE VIDI U CELOJ KLASI
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            string naziv = naziv_tb.Text;
            string id = id_tb.Text;

            if(!Int32.TryParse(naziv, out int o))
            {
                if(id != "")
                {
                    if(new Posrednik().DodajPostojanje(id, naziv))
                    {
                        greskaId.Content = "";
                        id_tb.BorderBrush = Brushes.Green;
                        greskaNaziv.Content = "";
                        naziv_tb.BorderBrush = Brushes.Green;
                        MessageBox.Show("Podrucje dodato", "USPEH", MessageBoxButton.OK, MessageBoxImage.Information);

                        win.Update();   //NAD NJOM POZIVAM UPDATE //RADI
                        this.Close();
                    }
                    else
                    {
                        greskaId.Content = "Podrucje vec postoji!";
                        id_tb.BorderBrush = Brushes.Red;
                        greskaNaziv.Content = "podrucje vec postoji!";
                        naziv_tb.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    greskaId.Content = "ID ne sme biti prazan!";
                    id_tb.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                greskaNaziv.Content = "Naziv mora biti napisan slovima!";
                naziv_tb.BorderBrush = Brushes.Red;
            }

        }

        private void izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}




