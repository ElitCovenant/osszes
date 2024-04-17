using KonyvtarBackEnd.Models;
using KonyvtarKarbantarto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using KonyvtarKarbantarto.Dto;

namespace KonyvtarKarbantarto.Windows
{
    /// <summary>
    /// Interaction logic for KonyvKezelo.xaml
    /// </summary>
    public partial class KonyvKezelo : Window
    {
        string token = string.Empty;
        List<Book> konys = new List<Book>();
        public KonyvKezelo(string tok)
        {
            token = tok;
            InitializeComponent();
            konys = CRUD.GetBooks(token);
            Griddo.ItemsSource = konys;

        }
        private void GetDataKonyvek_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konys = CRUD.GetBooks(token);
                Griddo.ItemsSource = konys;
                Griddo.Items.Refresh();
            }
            catch (Exception r)
            {
                MessageBox.Show("Error : " + r.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            KarbantartoEloszto eloszto = new KarbantartoEloszto(token);
            eloszto.Show();
            this.Close();
        }

        private void CreateBook_Click(object sender, RoutedEventArgs e)
        {
            Konyvletrehozo konyvletrehozo = new Konyvletrehozo(token);
            konyvletrehozo.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Griddo.SelectedItem != null)
            {

                string question = "Biztosan szeretné törölni az adott könyvet?";
                string cap = "Figyelem!";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage image = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(question, cap, button, image);
                if (result.ToString() == "Yes")
                {
                    MessageBox.Show(CRUD.DeleteBook(token, (Griddo.SelectedItem as Book).Id));
                }
                Griddo.ItemsSource = CRUD.GetBooks(token);
            }
            
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (Griddo.SelectedItem != null)
            {
                KonyvSzerkeszto szerkeszto = new KonyvSzerkeszto(token, Griddo.SelectedItem as Book);
                szerkeszto.ShowDialog();
                Griddo.ItemsSource = CRUD.GetBooks(token);
                Griddo.Items.Refresh();
            }
        }
    }
}
