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
    /// Interaction logic for FelhasznaloEdit.xaml
    /// </summary>
    public partial class FelhasznaloEdit : Window
    {
        string token;
        User editenro = new User();
        Connection connection = new Connection();
        public FelhasznaloEdit(string tok,User user)
        {
            token = tok;
            List<User> list = new List<User>();
            InitializeComponent();
            list.Add(user);
            Griddo.ItemsSource = list;
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            string converter = webClient.DownloadString(connection.Url() + "Rule");
            
            var jog = JsonConvert.DeserializeObject<List<RulesDto>>(converter).ToList();
            foreach (var item in jog)
            {
                JogComb.Items.Add(item.Id+"-"+item.Name);
            }
            
            converter = webClient.DownloadString(connection.Url() + "GetData");
            MessageBox.Show(converter);
            List<AccountImgDto> imgs = JsonConvert.DeserializeObject<List<AccountImgDto>>(converter).ToList();
            foreach (var item in imgs)
            {
                AccountComb.Items.Add(item.Id + "-" + item.ImgName);
            }

            JogComb.SelectedIndex = 1;
            AccountComb.SelectedIndex = 0;

        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                bool alkalmas = false;
                WebClient webClient = new WebClient();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                webClient.Encoding = Encoding.UTF8;

                //string result = webClient.UploadString(connection.Url() + "Register", "POST", JsonConvert.SerializeObject(register));
                //MessageBox.Show(result);

            }
            catch (Exception x)
            {

                MessageBox.Show("Error! :" + x.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Felhszerk felhszerk = new Felhszerk(token);
            felhszerk.Show();
            this.Close();
        }
    }
}
