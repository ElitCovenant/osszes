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
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using KonyvtarKarbantarto.Models;

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
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Register register = new Register();
                register.userName = Email_Adress.Text.ToLower().Trim()+"@kkszki.hu";
                register.hash = Password.Text;
                MessageBox.Show(CRUD.RegisterUser(token,register));
                this.Close();
            }
            catch (Exception x)
            {

                MessageBox.Show("Error! :"+x.Message);
            }
        }

        private void ReadFromFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Multiselect = false;
                open.DefaultExt = ".txt";
                open.ShowDialog();
                string[] data = File.ReadAllLines(open.FileName);
                Transfer transfer = new Transfer();
                for (int i = 0; i < data.Length; i++)
                {
                    if (i<data.Length-1)
                    {
                        transfer.transfer += data[i]+",";
                    }
                    else
                    {
                        transfer.transfer += data[i];
                    }                
                }
                MessageBox.Show(CRUD.AOEregister(token,transfer));
            }

            catch (Exception r)
            {
                MessageBox.Show("Error :" + r.Message);
            }
        }
    }
}
