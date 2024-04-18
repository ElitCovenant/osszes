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
        List<Book> books = new List<Book>();
        LoanHistoryDto history = new LoanHistoryDto();
        public KolcsonzesEdit(string tok, LoanHistory putloan)
        {
            token = tok;
            history = new LoanHistoryDto
            {
                id = putloan.Id,
                book_Id = putloan.BookId,
                user_Id = (uint)putloan.UserId,
                startDate = DateFormer(putloan.Date.ToString()),
                deadline = DateFormer(putloan.DateEnd.ToString()),
                returned = putloan.Returned,
                comment = putloan.Comment

            };
            InitializeComponent();

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

            books = CRUD.GetBooks(token);
            foreach (var book in books)
            {
                BookId.Items.Add($"{book.Id} , {book.Title}");
            }
            BookId.SelectedItem = $"{putloan.BookId} , {books.FirstOrDefault(x => x.Id == putloan.BookId).Title}";

            var users = CRUD.GetUsers(token);
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

            LoanHistoryDto loan = new LoanHistoryDto() { 
                id = history.id,
                book_Id = Convert.ToUInt32(BookId.SelectedItem.ToString().Split(',')[0].Trim()),
                user_Id = Convert.ToUInt32(UserId.SelectedItem.ToString().Split(',')[0].Trim()),
                startDate = $"{YearS.SelectedItem}-{SecurerDate((MonthS.SelectedItem.ToString()))}-{DayS.SelectedItem}",
                deadline = $"{YearE.SelectedItem}-{SecurerDate(MonthE.SelectedItem.ToString())}-{DayE.SelectedItem}",
                returned = history.returned,
                comment = Comment.Text
            };

            MessageBox.Show(CRUD.PutLoan(token,history.id,loan));
            this.Close();
        }
    }
}
