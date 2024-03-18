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
        UserEditDto editenro = new UserEditDto();
        uint id;
        Connection connection = new Connection();
        public FelhasznaloEdit(string tok,User user)
        {
            editenro.id = user.Id;
            editenro.membershipStart = Convert.ToString(user.MembershipStart);
            editenro.membershipEnd = Convert.ToString(user.MembershipEnd);
            editenro.userName = user.Usarname;
            editenro.id_Rule = user.IdRule;
            editenro.id_Account_Image = user.IdAccountImg;
            id = user.Id;
            token = tok;

            InitializeComponent();

            Ev.Text = DateFormer(editenro.membershipStart).Split('-')[0];
            Honap.Text = DateFormer(editenro.membershipStart).Split('-')[1];
            Nap.Text = DateFormer(editenro.membershipStart).Split('-')[2];

            E_Ev.Text = DateFormer(editenro.membershipEnd).Split('-')[0];
            E_Honap.Text = DateFormer(editenro.membershipEnd).Split('-')[1];
            E_Nap.Text = DateFormer(editenro.membershipEnd).Split('-')[2];
            Email.Text = user.Usarname;

            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            string converter = webClient.DownloadString(connection.Url() + "Rule");
            
            var jog = JsonConvert.DeserializeObject<List<RulesDto>>(converter).ToList();
            for (int i = 0; i < jog.Count; i++)
            {
                JogComb.Items.Add(jog[i].Id + "-" + jog[i].Name);

                if (jog[i].Id == user.IdRule)
                {
                    JogComb.SelectedIndex = i;
                }
                
            }
            
            converter = webClient.DownloadString(connection.Url() + "GetData");
            MessageBox.Show(converter);
            List<AccountImgDto> imgs = JsonConvert.DeserializeObject<List<AccountImgDto>>(converter).ToList();
            for (int i = 0; i < imgs.Count; i++)
            {
                AccountComb.Items.Add(imgs[i].Id + "-" + imgs[i].ImgName);
                if (imgs[i].Id == user.IdAccountImg)
                {
                    AccountComb.SelectedIndex = i;
                }
            }


        }

        public static string DateFormer(string cucc)
        {
            if (cucc.Contains('.'))
            {
                string[] partone = cucc.Split(' ');

                return partone[0].Replace('.', ' ').Trim() + "-" + partone[1].Replace('.', ' ').Trim() + "-" + partone[2].Replace('.', ' ').Trim();

            }
            else
            {
                return cucc;
            }
            
        }

        public static string DateSecure(string cucc)
        {
            if (int.TryParse(cucc,out int D))
            {
                return cucc;
            }
            else
            {
                return "0000";
            }
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                bool alkalmas = false;
                WebClient webClient = new WebClient();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                webClient.Encoding = Encoding.UTF8;

                
                editenro.userName = Email.Text;
                editenro.membershipStart = DateSecure(Ev.Text)+"-"+DateSecure(Honap.Text)+"-"+DateSecure(Nap.Text);
                editenro.membershipEnd = DateSecure(E_Ev.Text) + "-" + DateSecure(E_Honap.Text) + "-" + DateSecure(E_Nap.Text);
                editenro.id_Rule = Convert.ToInt32(JogComb.SelectedItem.ToString().Split('-')[0]);
                editenro.id_Account_Image = Convert.ToInt32(AccountComb.SelectedItem.ToString().Split('-')[0]);
                MessageBox.Show(JsonConvert.SerializeObject(editenro));

                string result = webClient.UploadString(connection.Url() + $"User/{id}", "PUT", JsonConvert.SerializeObject(editenro));
                MessageBox.Show(DateTime.Now.ToString());

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