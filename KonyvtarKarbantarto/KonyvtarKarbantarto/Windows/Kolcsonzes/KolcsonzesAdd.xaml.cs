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

            books = CRUD.GetBooks(token);
            foreach (var book in books)
            {
                BookId.Items.Add($"{book.Id} , {book.Title}");
            }
            BookId.SelectedIndex = 0;

            var users = CRUD.GetUsers(token);
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
                    MessageBox.Show(CRUD.PostLoan(token,history)+"\n"+CRUD.BorrowChange(token, history.id, borrow));
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
