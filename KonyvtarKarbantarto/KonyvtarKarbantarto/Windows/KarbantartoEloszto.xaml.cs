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

namespace KonyvtarKarbantarto.Windows
{
    /// <summary>
    /// Interaction logic for KarbantartoEloszto.xaml
    /// </summary>
    public partial class KarbantartoEloszto : Window
    {
        string token = string.Empty;
        public KarbantartoEloszto(string tok)
        {
            token = tok;
            InitializeComponent();
        }

        private void Felh_Szerk_Click(object sender, RoutedEventArgs e)
        {
            Felhszerk felhszerk = new Felhszerk(token);
            felhszerk.Show();
            this.Close();
        }

        private void KonyKez_Click(object sender, RoutedEventArgs e)
        {
            KonyvKezelo konyvKezelo = new KonyvKezelo(token);
            konyvKezelo.Show();
            this.Close();
        }
    }
}
