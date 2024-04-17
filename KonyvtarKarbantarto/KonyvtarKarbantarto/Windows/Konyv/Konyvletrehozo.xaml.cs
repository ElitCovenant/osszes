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
        string PicPath;
        public Konyvletrehozo(string tok)
        {
            token = tok;
            InitializeComponent();

            for (int i = 2000; i <= DateTime.Now.AddYears(1).Year; i++)
            {
                Ev.Items.Add(i);
            }
            Ev.SelectedItem = DateTime.Now.Year;

            for (int i = 1; i <= 12; i++)
            {
                Honap.Items.Add(i);
            }
            Honap.SelectedItem = DateTime.Now.Month;

            for (int i = 1; i <= 31; i++)
            {
                Nap.Items.Add(i);
            }
            Nap.SelectedItem = DateTime.Now.Day;

            List<Author> authors = CRUD.GetAuthors(token);
            for (int i = 0; i < authors.Count; i++)
            {
                AuthorId.Items.Add(authors[i].Id + "-" + authors[i].Name);
            }
            AuthorId.SelectedIndex = 0;

            List<Series> seriesList = CRUD.GetSeries(token);
            for (int i = 0; i < seriesList.Count; i++)
            {
                Series.Items.Add(seriesList[i].Id + "-" + seriesList[i].Name);
            }
            Series.SelectedIndex = 0;

            List<PublisherObject> publishers = CRUD.GetPublisher(token);
            for (int i = 0; i < publishers.Count; i++)
            {
                PublisherId.Items.Add(publishers[i].Id + "-" + publishers[i].Name);
            }
            PublisherId.SelectedIndex = 0;
        }
        BookDto book = new BookDto();
        public static int Securer(string c)
        {
            if (int.TryParse(c, out int g))
            {
                return g;
            }
            else
            {
                return 0000;
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
                return "0000";
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

                book.warehouse_Num = Securer(WarhNum.Text);
                book.purchase_Date = Ev.SelectedItem.ToString() + "-" + SecurerDate(Honap.SelectedItem.ToString()).ToString() + "-" + SecurerDate(Nap.SelectedItem.ToString()).ToString();
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
                book.user_Id = 1;
                if (PicPath != null&&Uploading.IsChecked == true)
                {
                    
                    string ftpUrl = "ftp://ftp.nethely.hu/img";
                    string userName = "szovetsege";
                    string password = "Szovetsege241";

                    // Get the file name without the path
                    var fileName = PicPath.Split('\\').Last();
                    book.bookImg = Picture.Text;
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl + "/" + fileName);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(userName, password);
                    request.UseBinary = true;

                    byte[] fileContents;
                    using (FileStream fileStream = File.OpenRead(PicPath))
                    {
                        fileContents = new byte[fileStream.Length];
                        fileStream.Read(fileContents, 0, fileContents.Length);
                    }

                    // Upload file
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                    }

                    // Get response
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        MessageBox.Show($"Upload complete. Server response: {response.StatusDescription}");
                    }
                }
                else
                {
                    book.bookImg = "http://img.library.nhely.hu/img/default_book_img.png";
                }
                MessageBox.Show(CRUD.PostBooks(token,book));
                PicPath = null;
                book = new BookDto();
            }
            catch (WebException ex)
            {
                // Handle WebException separately to provide specific error messages
                if (ex.Response != null)
                {
                    MessageBox.Show($"FTP Error: {ex.Message}");
                }
                else
                {
                    MessageBox.Show($"WebException: {ex.Message}");
                }
            }
            catch (Exception p)
            {

                MessageBox.Show("Error! :" + p.Message);
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
                    PicPath = fileDialog.FileName;
                    string ftpServerUrl = "http://img.library.nhely.hu/";
                    Picture.Text = ftpServerUrl + "img/" + fileDialog.FileName.Split('\\').Last();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }

    }
}
