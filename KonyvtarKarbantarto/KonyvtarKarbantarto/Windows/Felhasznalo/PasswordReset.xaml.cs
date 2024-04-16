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
        public PasswordReset(string tok, User user)
        {
            token = tok;
            resetpassword = user;
            InitializeComponent();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                UserPasswordReset passwordReset = new UserPasswordReset() { hash = NewPassword.Text };
                MessageBox.Show(CRUD.PasswordReset(token,passwordReset,resetpassword.Id));
                this.Close();
            }
            catch (Exception h)
            {
                MessageBox.Show("Error! : " + h.Message);
            }

        }
    }
}
