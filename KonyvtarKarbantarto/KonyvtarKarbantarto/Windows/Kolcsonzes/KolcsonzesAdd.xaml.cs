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
    /// Interaction logic for KolcsonzesAdd.xaml
    /// </summary>
    public partial class KolcsonzesAdd : Window
    {
        string token;
        Connection connection = new Connection();
        List<Book> books = new List<Book>();
        public KolcsonzesAdd(string tok)
        {
            token = tok;
            InitializeComponent();

            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            for (int i = 2000; i <= DateTime.Now.AddYears(5).Year; i++)
            {
                YearE.Items.Add(i);
                YearS.Items.Add(i);
            }
            YearE.SelectedItem = DateTime.Now.AddYears(5).Year;
            YearS.SelectedItem = DateTime.Now.Year;

            for (int i = 1; i <= 12; i++)
            {
                MonthE.Items.Add(i);
                MonthS.Items.Add(i);
            }
            MonthE.SelectedItem = 6;
            MonthS.SelectedItem = DateTime.Now.Month;

            for (int i = 1; i <= 31; i++)
            {
                DayE.Items.Add(i);
                DayS.Items.Add(i);
            }
            DayE.SelectedItem = 16;
            DayS.SelectedItem = DateTime.Now.Day;

            books = JsonConvert.DeserializeObject<List<Book>>(webClient.DownloadString(connection.Url() + "Book")).ToList();
            foreach (var book in books)
            {
                BookId.Items.Add($"{book.Id} , {book.Title}");
            }
            BookId.SelectedIndex = 0;

            var users = JsonConvert.DeserializeObject<List<User>>(webClient.DownloadString(connection.Url() + "User"));
            foreach (var user in users)
            {
                UserId.Items.Add($"{user.Id} , {user.Usarname}");
            }
            UserId.SelectedIndex = 0;

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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (books.First(x => x.Id == Convert.ToInt32(BookId.SelectedItem.ToString().Split(',')[0].Trim())).UserId != 1)
            {
                MessageBox.Show("A könyv már ki van kölcsönözve");
                this.Close();
            }
            else
            {
                WebClient webClient = new WebClient();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                webClient.Encoding = Encoding.UTF8;
                try
                {
                    LoanHistoryDto history = new LoanHistoryDto()
                    {
                        id = 0,
                        book_Id = Convert.ToInt32(BookId.SelectedItem.ToString().Split(',')[0].Trim()),
                        user_Id = Convert.ToInt32(UserId.SelectedItem.ToString().Split(',')[0].Trim()),
                        startDate = $"{YearS.SelectedItem}-{SecurerDate((MonthS.SelectedItem.ToString()))}-{DayS.SelectedItem}",
                        deadline = $"{YearE.SelectedItem}-{SecurerDate(MonthE.SelectedItem.ToString())}-{DayE.SelectedItem}",
                        returned = false,
                        comment = Comment.Text
                    };
                        BorrowUserChangeDto borrow = new BorrowUserChangeDto()
                        {
                            id = (uint)history.user_Id
                        };
                    MessageBox.Show(webClient.UploadString(connection.Url() + "LoanHistory", "POST", JsonConvert.SerializeObject(history)));

                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";

                    webClient.Encoding = Encoding.UTF8;

                    webClient.UploadString(connection.Url() + "BorrowUserChange/" + history.book_Id.ToString(), "PUT", JsonConvert.SerializeObject(borrow));

                    this.Close();
                }
                catch (Exception r)
                {
                    MessageBox.Show("Error! :" + r.Message);
                }

            }

        }
    }
}
