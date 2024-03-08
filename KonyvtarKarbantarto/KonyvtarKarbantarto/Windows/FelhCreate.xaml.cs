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
using Newtonsoft.Json;

namespace KonyvtarKarbantarto.Windows
{
    /// <summary>
    /// Interaction logic for FelhCreate.xaml
    /// </summary>
    public partial class FelhCreate : Window
    {
        string token = string.Empty;
        public FelhCreate(string tok)
        {
            token = tok;
            InitializeComponent();
        }
        Connection connection = new Connection();
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            try
            {
                Register register = new Register();
                register.userName = Email_Adress.Text.ToLower().Trim()+"@kkszki.hu";
                register.hash = Password.Text;
                string result = webClient.UploadString(connection.Url() + "Register", "POST", JsonConvert.SerializeObject(register));
                MessageBox.Show(result);

            }
            catch (Exception x)
            {

                MessageBox.Show("Error! :"+x.Message);
            }
        }
    }
}
