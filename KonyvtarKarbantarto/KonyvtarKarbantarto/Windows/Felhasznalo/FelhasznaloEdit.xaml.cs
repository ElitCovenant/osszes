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

            for (int i = 2000; i <= DateTime.Now.AddYears(5).Year; i++)
            {
                Ev.Items.Add(i);
                if (Convert.ToInt32(editenro.membershipStart.ToString().Split('.')[0]) == i)
                {
                    Ev.SelectedItem = i;
                }
                E_Ev.Items.Add(i);
                if (Convert.ToInt32(editenro.membershipEnd.ToString().Split('.')[0].Trim()) == i)
                {
                    E_Ev.SelectedItem = i;
                }
            }


            for (int i = 1; i <= 12; i++)
            {
                Honap.Items.Add(i);
                if (Convert.ToInt32(editenro.membershipStart.ToString().Split('.')[1].Trim()) == i)
                {
                    Honap.SelectedItem = i;
                }
                E_Honap.Items.Add(i);
                if (Convert.ToInt32(editenro.membershipEnd.ToString().Split('.')[1].Trim()) == i)
                {
                    E_Honap.SelectedItem = i;
                }
            }

            for (int i = 1; i <= 31; i++)
            {
                Nap.Items.Add(i);
                if (Convert.ToInt32(editenro.membershipStart.ToString().Split('.')[2].Trim()) == i)
                {
                    Nap.SelectedItem = i;
                }
                E_Nap.Items.Add(i);
                if (Convert.ToInt32(editenro.membershipEnd.ToString().Split('.')[2].Trim()) == i)
                {
                    E_Nap.SelectedItem = i;
                }
            }

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

        public static string SecurerDate(string c)
        {
            if (int.TryParse(c, out int g))
            {
                if (g < 10 && !c.Contains('0'))
                {
                    return 0 + c;
                }
                else
                {
                    return c;
                }

            }
            else
            {
                return "00";
            }
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                webClient.Encoding = Encoding.UTF8;

                
                editenro.userName = Email.Text;
                editenro.membershipStart = Ev.SelectedItem.ToString()+"-"+SecurerDate(Honap.SelectedItem.ToString())+"-"+SecurerDate(Nap.SelectedItem.ToString());
                editenro.membershipEnd = E_Ev.SelectedItem.ToString() + "-" + SecurerDate(E_Honap.SelectedItem.ToString()) + "-" + SecurerDate(E_Nap.SelectedItem.ToString());
                editenro.id_Rule = Convert.ToInt32(JogComb.SelectedItem.ToString().Split('-')[0]);
                editenro.id_Account_Image = Convert.ToInt32(AccountComb.SelectedItem.ToString().Split('-')[0]);
                

                string result = webClient.UploadString(connection.Url() + $"User/{id}", "PUT", JsonConvert.SerializeObject(editenro));
                MessageBox.Show(result);
                this.Close();
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