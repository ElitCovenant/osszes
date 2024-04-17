using KonyvtarBackEnd.Models;
using KonyvtarKarbantarto.Dto;
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

namespace KonyvtarKarbantarto.Windows
{
    /// <summary>
    /// Interaction logic for EgyebKezelo.xaml
    /// </summary>
    public partial class EgyebKezelo : Window
    {
        string token;
        string currenttask;
        public EgyebKezelo(string token, string currenttask)
        {
            this.token = token;
            this.currenttask = currenttask;
            InitializeComponent();
            switch (currenttask)
            {
                case ("Author"):
                    this.Title = "Szerző";
                    break;
                case ("Series"):
                    this.Title = "Sorozat";
                    break;
                case ("Publisher"):
                    this.Title = "Kiadó";
                    break;
                default:
                    this.Title = "NotFound";
                    break;
            }

            Griddo.ItemsSource = CRUD.APSGet(token,currenttask);
            Griddo.Items.Refresh();
        }



        private void GetData_Click(object sender, RoutedEventArgs e)
        {
            Griddo.ItemsSource = CRUD.APSGet(token, currenttask);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            EgyebSzerkeszto egyeb = new EgyebSzerkeszto(token, currenttask);
            egyeb.ShowDialog();
            Griddo.ItemsSource = CRUD.APSGet(token, currenttask);
            Griddo.Items.Refresh();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Griddo.SelectedItem != null)
            {
                EgyebSzerkeszto egyeb = new EgyebSzerkeszto(token, currenttask, Griddo.SelectedItem as EgyebDto);
                egyeb.ShowDialog();
                Griddo.ItemsSource = CRUD.APSGet(token, currenttask);
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Griddo.SelectedItem != null)
            {
                string question = "Biztosan szeretné törölni az adott elemet?";
                string cap = "Figyelem!";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage image = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(question, cap, button, image);
                if (result.ToString() == "Yes")
                {
                    MessageBox.Show(CRUD.APSDelete(token, (Griddo.SelectedItem as EgyebDto).id, currenttask));
                }
                Griddo.ItemsSource = CRUD.APSGet(token, currenttask);
                Griddo.Items.Refresh();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            KarbantartoEloszto eloszto = new KarbantartoEloszto(token);
            eloszto.Show();
            this.Close();
        }
    }
}
