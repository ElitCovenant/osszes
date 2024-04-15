﻿using KonyvtarBackEnd.Models;
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
using KonyvtarKarbantarto.Dto;

namespace KonyvtarKarbantarto.Windows
{
    /// <summary>
    /// Interaction logic for KonyvKezelo.xaml
    /// </summary>
    public partial class KonyvKezelo : Window
    {
        string token = string.Empty;
        List<Book> konys = new List<Book>();
        public KonyvKezelo(string tok)
        {
            token = tok;
            InitializeComponent();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            string result = webClient.DownloadString(connection.Url() + "Book");
            konys = JsonConvert.DeserializeObject<List<Book>>(result).ToList();
            Griddo.ItemsSource = konys;

        }
        Connection connection = new Connection();
        private void GetDataKonyvek_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization,"Bearer "+token);
            webClient.Encoding = Encoding.UTF8;
            try
            {
                string result = webClient.DownloadString(connection.Url()+"Book");
                konys = JsonConvert.DeserializeObject<List<Book>>(result).ToList();
                Griddo.ItemsSource = konys;
                Griddo.Items.Refresh();
            }
            catch (Exception r)
            {
                MessageBox.Show("Error : " + r.Message);
            }


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            KarbantartoEloszto eloszto = new KarbantartoEloszto(token);
            eloszto.Show();
            this.Close();
        }

        private void CreateBook_Click(object sender, RoutedEventArgs e)
        {
            Konyvletrehozo konyvletrehozo = new Konyvletrehozo(token);
            konyvletrehozo.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Griddo.SelectedItem != null)
            {
                WebClient webClient = new WebClient();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                webClient.Encoding = Encoding.UTF8;

                string question = "Biztosan szeretné törölni az adott könyvet?";
                string cap = "Figyelem!";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage image = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(question, cap, button, image);
                if (result.ToString() == "Yes")
                {
                    MessageBox.Show(webClient.UploadString(connection.Url() + $"Book/{(Griddo.SelectedItem as Book).Id}", "Delete", ""));
                }
                Griddo.ItemsSource = JsonConvert.DeserializeObject<List<Book>>(webClient.DownloadString(connection.Url()+"Book")).ToList();
            }
            
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (Griddo.SelectedItem != null)
            {
                WebClient webClient = new WebClient();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                webClient.Encoding = Encoding.UTF8;

                KonyvSzerkeszto szerkeszto = new KonyvSzerkeszto(token, Griddo.SelectedItem as Book);
                szerkeszto.ShowDialog();
                Griddo.ItemsSource = JsonConvert.DeserializeObject<List<Book>>(webClient.DownloadString(connection.Url() + "Book")).ToList();
            }
        }
    }
}