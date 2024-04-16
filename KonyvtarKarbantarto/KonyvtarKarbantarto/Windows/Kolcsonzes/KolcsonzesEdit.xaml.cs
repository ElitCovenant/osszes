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
    /// Interaction logic for KolcsonzesEdit.xaml
    /// </summary>
    public partial class KolcsonzesEdit : Window
    {
        string token;
        Connection connection = new Connection();
        List<Book> books = new List<Book>();
        LoanHistoryDto history = new LoanHistoryDto();
        public KolcsonzesEdit(string tok, LoanHistory putloan)
        {
            token = tok;
            history = new LoanHistoryDto
            {
                id = (int)putloan.Id,
                book_Id = (int)putloan.BookId,
                user_Id = (int)putloan.UserId,
                startDate = DateFormer(putloan.Date.ToString()),
                deadline = DateFormer(putloan.DateEnd.ToString()),
                returned = putloan.Returned,
                comment = putloan.Comment

            };
            InitializeComponent();

            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            MessageBox.Show($"{putloan.Date.ToString().Split('.')[0].Trim()}");

            for (int i = 2000; i <= DateTime.Now.AddYears(5).Year; i++)
            {
                YearE.Items.Add(i);
                if (Convert.ToInt32(putloan.DateEnd.ToString().Split('.')[0]) == i)
                {
                    YearE.SelectedItem = i;
                }
                YearS.Items.Add(i);
                if (Convert.ToInt32(putloan.Date.ToString().Split('.')[0].Trim()) == i)
                {
                    YearS.SelectedItem = i;
                }
            }

            MessageBox.Show($"{YearS.SelectedItem}");

            for (int i = 1; i <= 12; i++)
            {
                MonthE.Items.Add(i);
                if (Convert.ToInt32(putloan.DateEnd.ToString().Split('.')[1].Trim()) == i)
                {
                    MonthE.SelectedItem = i;
                }
                MonthS.Items.Add(i);
                if (Convert.ToInt32(putloan.Date.ToString().Split('.')[1].Trim()) == i)
                {
                    MonthS.SelectedItem = i;
                }
            }

            for (int i = 1; i <= 31; i++)
            {
                DayE.Items.Add(i);
                if (Convert.ToInt32(putloan.DateEnd.ToString().Split('.')[2].Trim()) == i)
                {
                    DayE.SelectedItem = i;
                }
                DayS.Items.Add(i);
                if (Convert.ToInt32(putloan.Date.ToString().Split('.')[2].Trim()) == i)
                {
                    DayS.SelectedItem = i;
                }
            }

            books = JsonConvert.DeserializeObject<List<Book>>(webClient.DownloadString(connection.Url() + "Book")).ToList();
            foreach (var book in books)
            {
                BookId.Items.Add($"{book.Id} , {book.Title}");
            }
            BookId.SelectedItem = $"{putloan.BookId} , {books.FirstOrDefault(x => x.Id == putloan.BookId).Title}";

            var users = JsonConvert.DeserializeObject<List<User>>(webClient.DownloadString(connection.Url() + "User"));
            foreach (var user in users)
            {
                UserId.Items.Add($"{user.Id} , {user.Usarname}");
            }
            UserId.SelectedItem = $"{putloan.UserId} , {users.FirstOrDefault(x => x.Id == putloan.UserId).Usarname}";
        }

        public static string DateFormer(string g)
        {
            return $"{g.Split('.')[0].Trim()}-{g.Split('.')[1].Trim()}-{g.Split('.')[2].Trim()}";
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

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            LoanHistoryDto loan = new LoanHistoryDto() { 
                id = history.id,
                book_Id = Convert.ToInt32(BookId.SelectedItem.ToString().Split(',')[0].Trim()),
                user_Id = Convert.ToInt32(UserId.SelectedItem.ToString().Split(',')[0].Trim()),
                startDate = $"{YearS.SelectedItem}-{SecurerDate((MonthS.SelectedItem.ToString()))}-{DayS.SelectedItem}",
                deadline = $"{YearE.SelectedItem}-{SecurerDate(MonthE.SelectedItem.ToString())}-{DayE.SelectedItem}",
                returned = history.returned,
                comment = Comment.Text
            };

            MessageBox.Show(webClient.UploadString(connection.Url() + "LoanHistory/"+history.id, "PUT", JsonConvert.SerializeObject(loan)));
            this.Close();
        }
    }
}
