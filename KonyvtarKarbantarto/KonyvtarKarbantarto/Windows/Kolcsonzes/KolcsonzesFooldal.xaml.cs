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

namespace KonyvtarKarbantarto.Windows.Kolcsonzes
{
    /// <summary>
    /// Interaction logic for KolcsonzesFooldal.xaml
    /// </summary>
    public partial class KolcsonzesFooldal : Window
    {
        string token;
        Connection connection = new Connection();
        public KolcsonzesFooldal(string tok)
        {
            token = tok;
            InitializeComponent();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            string result = webClient.DownloadString(connection.Url() + "LoanHistory");
            Griddo.ItemsSource = JsonConvert.DeserializeObject<List<LoanHistory>>(result).ToList();
        }

        private void EditLoan_Click(object sender, RoutedEventArgs e)
        {
            if (Griddo.SelectedItem != null)
            {
                KolcsonzesEdit edit = new KolcsonzesEdit(token, Griddo.SelectedItem as LoanHistory);
                edit.ShowDialog();
            }

        }

        private void CreateLoan_Click(object sender, RoutedEventArgs e)
        {
            KolcsonzesAdd add = new KolcsonzesAdd(token);
            add.ShowDialog();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            string result = webClient.DownloadString(connection.Url() + "LoanHistory");
            Griddo.ItemsSource = JsonConvert.DeserializeObject<List<LoanHistory>>(result).ToList();
        }

        private void GetDataLoan_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            string result = webClient.DownloadString(connection.Url() + "LoanHistory");
            Griddo.ItemsSource = JsonConvert.DeserializeObject<List<LoanHistory>>(result).ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            KarbantartoEloszto eloszto = new KarbantartoEloszto(token);
            eloszto.Show();
            this.Close();
        }

        public static string DateFormer(string g)
        {
            return $"{g.Split('.')[0].Trim()}-{g.Split('.')[1].Trim()}-{g.Split('.')[2].Trim()}";
        }

        private void Returned_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                webClient.Encoding = Encoding.UTF8;

                if (Griddo.SelectedItem != null)
                {
                    if ((Griddo.SelectedItem as LoanHistory).Returned)
                    {
                        MessageBox.Show("Az adott kölcsönzés már befejeződött");
                    }
                    else
                    {
                        LoanHistoryDto historyDto = new LoanHistoryDto()
                        {
                            id = (int)(Griddo.SelectedItem as LoanHistory).Id,
                            book_Id = (int)(Griddo.SelectedItem as LoanHistory).BookId,
                            user_Id = (int)(Griddo.SelectedItem as LoanHistory).UserId,
                            startDate = DateFormer((Griddo.SelectedItem as LoanHistory).Date.ToString()),
                            deadline = DateFormer((Griddo.SelectedItem as LoanHistory).DateEnd.ToString()),
                            returned = true,
                            comment = (Griddo.SelectedItem as LoanHistory).Comment
                        };
                        webClient.UploadString(connection.Url() + "LoanHistory/" + historyDto.id, "PUT", JsonConvert.SerializeObject(historyDto));

                        webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                        webClient.Encoding = Encoding.UTF8;

                        BorrowUserChangeDto changeDto = new BorrowUserChangeDto()
                        {
                            id = 1
                        };

                        webClient.UploadString(connection.Url() + "BorrowUserChange/" + historyDto.book_Id, "PUT", JsonConvert.SerializeObject(changeDto));

                        webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                        webClient.Encoding = Encoding.UTF8;

                        Griddo.ItemsSource = JsonConvert.DeserializeObject<List<LoanHistory>>(webClient.DownloadString(connection.Url() + "LoanHistory")).ToList();
                        Griddo.Items.Refresh();
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }

        }
    }
}
