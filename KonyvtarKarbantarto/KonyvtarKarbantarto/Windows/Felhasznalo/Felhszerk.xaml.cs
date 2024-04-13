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
    /// Interaction logic for Felhs.xaml
    /// </summary>
    public partial class Felhszerk : Window
    {
        string token = string.Empty;
        public Felhszerk(string tok)
        {
            token = tok;
            InitializeComponent();
            try
            {
                List<User> users = new List<User>();

                WebClient webClient = new WebClient();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string result = webClient.DownloadString(connection.Url() + "User");
                users = JsonConvert.DeserializeObject<List<User>>(result).ToList();
                //MessageBox.Show(result);
                Griddo.ItemsSource = users;
                Griddo.Items.Refresh();
            }
            catch (Exception r)
            {
                MessageBox.Show("Error : " + r.Message);
            }
        }
        Connection connection = new Connection();
        private void GetData_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            try
            {
                List<User> users = new List<User>();
                
                string result =  webClient.DownloadString(connection.Url() + "User");
                users = JsonConvert.DeserializeObject<List<User>>(result).ToList();
                //MessageBox.Show(result);
                Griddo.ItemsSource = users;
                Griddo.Items.Refresh();
            }
            catch (Exception r)
            {
                MessageBox.Show("Error : "+r.Message);
            }
            
        }

        private void Write_Click(object sender, RoutedEventArgs e)
        {
            if (Griddo.SelectedItem != null)
            {
                MessageBox.Show((Griddo.SelectedItem as User).Usarname);
            }
            else
            {
                MessageBox.Show("Nincs kijelölve semmi.");
            }
            
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            FelhCreate create = new FelhCreate(token);
            create.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            KarbantartoEloszto eloszto = new KarbantartoEloszto(token);
            eloszto.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Griddo.SelectedItem != null)
            {
                FelhasznaloEdit edit = new FelhasznaloEdit(token, Griddo.SelectedItem as User);
                edit.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nincs kijelölve semmi.");
            }
            
        }

        
    }
}
