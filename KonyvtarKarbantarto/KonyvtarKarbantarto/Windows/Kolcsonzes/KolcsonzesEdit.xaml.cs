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
        public KolcsonzesEdit(string tok, LoanHistory loan)
        {
            token = tok;
            InitializeComponent();

            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            MessageBox.Show($"{loan.Date.ToString().Split('.')[0].Trim()}");

            for (int i = 2000; i <= DateTime.Now.AddYears(5).Year; i++)
            {
                YearE.Items.Add(i);
                if (loan.DateEnd.ToString().Split('.')[0].Trim() == i.ToString())
                {
                    YearE.SelectedIndex = i;
                }
                YearS.Items.Add(i);
                if (loan.Date.ToString().Split('.')[0].Trim() == i.ToString())
                {
                    YearS.SelectedIndex = i;
                }
            }

            MessageBox.Show($"{YearS.SelectedItem}");

            for (int i = 1; i <= 12; i++)
            {
                MonthE.Items.Add(i);
                if (loan.DateEnd.ToString().Split('.')[1].Trim() == i.ToString())
                {
                    MonthE.SelectedIndex = i;
                }
                MonthS.Items.Add(i);
                if (loan.Date.ToString().Split('.')[1].Trim() == i.ToString())
                {
                    MonthS.SelectedIndex = i;
                }
            }

            for (int i = 1; i <= 31; i++)
            {
                DayE.Items.Add(i);
                if (loan.DateEnd.ToString().Split('.')[2].Trim() == i.ToString())
                {
                    DayE.SelectedIndex = i;
                }
                DayS.Items.Add(i);
                if (loan.Date.ToString().Split('.')[2].Trim() == i.ToString())
                {
                    DayS.SelectedIndex = i;
                }
            }

            books = JsonConvert.DeserializeObject<List<Book>>(webClient.DownloadString(connection.Url() + "Book")).ToList();
            foreach (var book in books)
            {
                BookId.Items.Add($"{book.Id} , {book.Title}");
            }
            BookId.SelectedItem = $"{loan.BookId} , {books.FirstOrDefault(x => x.Id == loan.BookId).Title}";

            var users = JsonConvert.DeserializeObject<List<User>>(webClient.DownloadString(connection.Url() + "User"));
            foreach (var user in users)
            {
                UserId.Items.Add($"{user.Id} , {user.Usarname}");
            }
            UserId.SelectedItem = $"{loan.UserId} , {users.FirstOrDefault(x=>x.Id == loan.UserId).Usarname}";
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
