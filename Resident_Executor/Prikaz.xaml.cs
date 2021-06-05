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
using System.ComponentModel;
using ResidentExecutor;

namespace Resident_Executor
{
    /// <summary>
    /// Interaction logic for Prikaz.xaml
    /// </summary>
    public partial class Prikaz : Window
    {
        public Prikaz()
        {
            InitializeComponent();
            dataGridVar.ItemsSource = Functions.PodaciLista.Podaci;
            combo_funkc.Items.Add("Mininalna potrosnja");
            combo_funkc.Items.Add("Maximalna potrosnja");
            combo_funkc.Items.Add("Standardna devijacija");
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Combo_funkc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            new UpdateGrid().Update(combo_funkc.SelectedValue.ToString());
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            if(combo_funkc.SelectedValue != null)
            {
                new UpdateGrid().Update(combo_funkc.SelectedValue.ToString());
            }
        }
    }
}
