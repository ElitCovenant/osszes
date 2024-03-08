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
            
        }
        Connection connection = new Connection();
        private void GetDataKonyvek_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization,"Bearer "+token);
            webClient.Encoding = Encoding.UTF8;
            MessageBox.Show(token);
            try
            {
                

                string result = webClient.DownloadString(connection.Url()+"Book");
                konys = JsonConvert.DeserializeObject<List<Book>>(result).ToList();
                //MessageBox.Show(result);
                Griddo.ItemsSource = konys;
                Griddo.Items.Refresh();
            }
            catch (Exception r)
            {
                MessageBox.Show("Error : " + r.Message);
            }


        }

        private void ShowKonyvek_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((Griddo.SelectedItem as Book).Title);
        }
    }
}
