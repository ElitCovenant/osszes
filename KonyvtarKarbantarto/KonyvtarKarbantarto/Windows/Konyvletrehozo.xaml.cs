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
using KonyvtarKarbantarto.Dto;
using System.IO;
using System.Security.Policy;

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
            
            List<PublisherObject> publishers = new List<PublisherObject>();

            publishers = JsonConvert.DeserializeObject<List<PublisherObject>>(webClient.DownloadString(connection.Url() + "Publisher")).ToList();
            for (int i = 0; i < publishers.Count; i++)
            {
                PublisherId.Items.Add(publishers[i].Id + "-" + publishers[i].Name);
            }
            PublisherId.SelectedIndex = 0;
        }
        BookDto book = new BookDto();
        public static int Securer(string c)
        {
            if (int.TryParse(c,out int g))
            {
                return g;
            }
            else
            {
                    return 0000;
            }
        }

        public static ushort SecurerShort(string c)
        {
            if (ushort.TryParse(c, out ushort g))
            {
                return g;
            }
            else
            {
                return 0000;
            }
        }

        public static decimal SecurerDecimal(string c)
        {
            if (decimal.TryParse(c, out decimal g))
            {
                return g;
            }
            else
            {
                return 0000;
            }
        }

        public static uint ComboSplitter(ComboBox combo)
        {
            return Convert.ToUInt32(combo.SelectedItem.ToString().Split('-')[0].Trim());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                webClient.Encoding = Encoding.UTF8;

                book.warehouse_Num = Securer(WarhNum.Text);
                book.purchase_Date = Securer(Ev.Text).ToString() + "-" + Securer(Honap.Text).ToString() + "-" + Securer(Nap.Text).ToString();
                book.author_Id = ComboSplitter(AuthorId);
                book.title = Title.Text;
                book.series_Id = ComboSplitter(Series);
                book.isbn_Num = SecurerDecimal(Isbnnum.Text);
                book.szakjelzet = SecurerDecimal(NobleNote.Text);
                book.cutter_Jelzet = CutterSign.Text;
                book.publisher_Id = ComboSplitter(PublisherId);
                book.release_Date = SecurerShort(Releasedate.Text);
                book.price = Securer(Price.Text);
                book.comment = Comment.Text;
                MessageBox.Show(JsonConvert.SerializeObject(book));
                MessageBox.Show(webClient.UploadString(connection.Url() + "Book", "POST", JsonConvert.SerializeObject(book)));
            }
            catch (Exception p)
            {

                MessageBox.Show("Error! :"+p.Message);
            }
        }

        private void Pic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileDialog = new Microsoft.Win32.OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.DefaultExt = ".png";
                fileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";

                // Show the dialog and check if the user selected a file
                if (fileDialog.ShowDialog() == true)
                {
                    string filePath = fileDialog.FileName;
                    MessageBox.Show(filePath);

                    string ftpUrl = "://img.library.nhely.hu";
                    string ftpServerUrl = "ftp" + ftpUrl;
                        string userName = "szovetsege";
                    string password = "Szovetsege241";

                    // Get the file name without the path
                    string fileName = filePath.Split('\\').Last();

                    // Create a WebClient instance
                    using (WebClient client = new WebClient())
                    {
                        // Set FTP credentials
                        client.Credentials = new NetworkCredential(userName, password);

                        // Upload the file
                        client.UploadFile($"{ftpServerUrl}/img/{filePath}", WebRequestMethods.Ftp.UploadFile, filePath);

                        // Show success message
                        MessageBox.Show("Upload File Complete");
                    }
                    MessageBox.Show("http" + ftpUrl + "/img/" + fileDialog.FileName.Split('\\').Last());
                    book.bookImg = "http"+ftpUrl + "/img/" + fileDialog.FileName.Split('\\').Last();

                }
            }
            catch (WebException ex)
            {
                // Handle WebException separately to provide specific error messages
                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    MessageBox.Show($"FTP Error: {response.StatusCode}, {response.StatusDescription}");
                }
                else
                {
                    MessageBox.Show($"WebException: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }

    }
}
