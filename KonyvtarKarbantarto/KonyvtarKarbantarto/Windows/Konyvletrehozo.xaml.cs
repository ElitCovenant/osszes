using KonyvtarBackEnd.Models;
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
    /// Interaction logic for Konyvtarletrehozo.xaml
    /// </summary>
    public partial class Konyvletrehozo : Window
    {
        string token;
        Connection connection = new Connection();
        public Konyvletrehozo(string tok)
        {
            token = tok;
            InitializeComponent();

            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            List<Author> authors = new List<Author>();

            authors = JsonConvert.DeserializeObject<List<Author>>(webClient.DownloadString(connection.Url() + "Author")).ToList();
            for (int i = 0; i < authors.Count; i++)
            {
                AuthorId.Items.Add(authors[i].Id + "-" + authors[i].Name);
            }
            AuthorId.SelectedIndex = 0;

            List<Series> seriesList = new List<Series>();

            seriesList = JsonConvert.DeserializeObject<List<Series>>(webClient.DownloadString(connection.Url()+"Series")).ToList();
            for (int i = 0; i < seriesList.Count; i++)
            {
                Series.Items.Add(seriesList[i].Id + "-" + seriesList[i].Name);
            }
            Series.SelectedIndex = 0;
            
            List<Publisher> publishers = new List<Publisher>();

            publishers = JsonConvert.DeserializeObject<List<Publisher>>(webClient.DownloadString(connection.Url() + "Publisher")).ToList();
            for (int i = 0; i < publishers.Count; i++)
            {
                PublisherId.Items.Add(publishers[i].Id + "-" + publishers[i].Name);
            }
            PublisherId.SelectedIndex = 0;
        }
    }
}
