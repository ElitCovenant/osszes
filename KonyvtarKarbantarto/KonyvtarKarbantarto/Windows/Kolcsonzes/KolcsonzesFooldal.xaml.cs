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

namespace KonyvtarKarbantarto.Windows.Kolcsonzes
{
    /// <summary>
    /// Interaction logic for KolcsonzesFooldal.xaml
    /// </summary>
    public partial class KolcsonzesFooldal : Window
    {
        string token;
        Connection connection = new Connection();
        public KolcsonzesFooldal(string tok)
        {
            token = tok;
            InitializeComponent();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            string result = webClient.DownloadString(connection.Url() + "LoanHistory");      
            Griddo.ItemsSource = JsonConvert.DeserializeObject<List<LoanHistory>>(result).ToList();
        }

        private void EditLoan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateLoan_Click(object sender, RoutedEventArgs e)
        {
            KolcsonzesAdd add = new KolcsonzesAdd(token);
            add.ShowDialog();
        }

        private void GetDataLoan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            KarbantartoEloszto eloszto= new KarbantartoEloszto(token);
            eloszto.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
