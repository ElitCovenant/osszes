using KonyvtarKarbantarto.Dto;
using KonyvtarKarbantarto.Models;
using KonyvtarKarbantarto.Windows.Felhasznalo;
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
                Griddo.ItemsSource = CRUD.GetUsers(token);
                Griddo.Items.Refresh();
            }
            catch (Exception r)
            {
                MessageBox.Show("Error : " + r.Message);
            }
        }
        private void GetData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Griddo.ItemsSource = CRUD.GetUsers(token);
                Griddo.Items.Refresh();
            }
            catch (Exception r)
            {
                MessageBox.Show("Error : "+r.Message);
            }
            
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            FelhCreate create = new FelhCreate(token);
            create.ShowDialog();
            Griddo.ItemsSource = CRUD.GetUsers(token);
            Griddo.Items.Refresh();
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
                edit.ShowDialog();
                Griddo.ItemsSource = CRUD.GetUsers(token);
                Griddo.Items.Refresh();
            }
            
        }

        private void PReset_Click(object sender, RoutedEventArgs e)
        {
            if (Griddo.SelectedItem != null)
            {
                PasswordReset passwordReset = new PasswordReset(token,Griddo.SelectedItem as User);
                passwordReset.ShowDialog();
            }
            //MessageBox.Show(result);
            Griddo.ItemsSource = CRUD.GetUsers(token);
            Griddo.Items.Refresh();
        }
    }
}
