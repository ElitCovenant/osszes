using KonyvtarKarbantarto.Dto;
using KonyvtarKarbantarto.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KonyvtarKarbantarto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class Login : Window
    {
        
        public Login()
        {
            InitializeComponent();
        }
        Connection connection = new Connection();

        private void windowchanger_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            try
            {
                LoginDto loginDto = new LoginDto();
                loginDto.userName = EmailAdress.Text;
                loginDto.hash = Password.Text;
                string result = webClient.UploadString(connection.Url()+"Login","POST",JsonConvert.SerializeObject(loginDto));
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(JsonConvert.DeserializeObject<Token>(result).troken);
                if (jwtSecurityToken.Claims.First(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value == "Admin")
                {
                    KarbantartoEloszto eloszto = new KarbantartoEloszto(JsonConvert.DeserializeObject<Token>(result).troken);
                    eloszto.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Önnek nincs hozzáférési joga az alkalmazáshoz!");
                }
                
            }
            catch (Exception g)
            {
                MessageBox.Show("Hiba történt a bejelentkezés alatt! : "+g.Message);
            }
            
        }
    }
}
