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

namespace KonyvtarKarbantarto.Windows.Felhasznalo
{
    /// <summary>
    /// Interaction logic for PasswordReset.xaml
    /// </summary>
    public partial class PasswordReset : Window
    {
        string token;
        User resetpassword;
        Connection connection = new Connection();
        public PasswordReset(string tok,User user)
        {
            token = tok;
            resetpassword = user;
            InitializeComponent();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;
            try
            {
                UserPasswordReset passwordReset = new UserPasswordReset() { hash = NewPassword.Text };
                MessageBox.Show(webClient.UploadString(connection.Url() + "jelszovaltas/" + resetpassword.Id, "PUT", JsonConvert.SerializeObject(passwordReset)));
                this.Close();
            }
            catch (Exception h)
            {
                MessageBox.Show("Error! : "+h.Message);
            }
            
        }
    }
}
