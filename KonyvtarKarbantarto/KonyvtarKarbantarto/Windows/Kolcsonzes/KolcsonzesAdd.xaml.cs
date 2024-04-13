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
        public KolcsonzesAdd(string tok)
        {
            token = tok;
            InitializeComponent();

            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            for (int i = 2000; i <= DateTime.Now.AddYears(1).Year; i++)
            {
                YearE.Items.Add(i);
                YearS.Items.Add(i);
            }
            YearE.SelectedItem = DateTime.Now.Year;
            YearS.SelectedItem = DateTime.Now.Year;

            for (int i = 1; i <= 12; i++)
            {
                MonthE.Items.Add(i);
                MonthS.Items.Add(i);
            }
            MonthE.SelectedItem = DateTime.Now.Month;
            MonthS.SelectedItem = DateTime.Now.Month;

            for (int i = 1; i <= 31; i++)
            {
                DayE.Items.Add(i);
                DayS.Items.Add(i);
            }
            DayE.SelectedItem = DateTime.Now.Day;
            DayS.SelectedItem = DateTime.Now.Day;

            var books = JsonConvert.DeserializeObject<List<BookDto>>(webClient.DownloadString(connection.Url()+"Book"));
            foreach (var book in books)
            {
                BookId.Items.Add($"{book.id} , {book.title}");
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

                //MessageBox.Show(JsonConvert.SerializeObject(history));
                MessageBox.Show(webClient.UploadString(connection.Url()+"LoanHistory","POST",JsonConvert.SerializeObject(history)));

            }
            catch (Exception r)
            { 
                MessageBox.Show("Error! :"+r.Message);
            }
        }
    }
}
