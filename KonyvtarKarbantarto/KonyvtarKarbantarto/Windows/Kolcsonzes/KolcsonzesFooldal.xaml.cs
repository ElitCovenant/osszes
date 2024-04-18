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
        public KolcsonzesFooldal(string tok)
        {
            token = tok;
            InitializeComponent();

            Griddo.ItemsSource = CRUD.GetLoans(token);
        }

        private void EditLoan_Click(object sender, RoutedEventArgs e)
        {
            if (Griddo.SelectedItem != null)
            {
                KolcsonzesEdit edit = new KolcsonzesEdit(token, Griddo.SelectedItem as LoanHistory);
                edit.ShowDialog();
            }

            Griddo.ItemsSource = CRUD.GetLoans(token);
            Griddo.Items.Refresh();

        }

        private void CreateLoan_Click(object sender, RoutedEventArgs e)
        {
            KolcsonzesAdd add = new KolcsonzesAdd(token);
            add.ShowDialog();
            Griddo.ItemsSource = CRUD.GetLoans(token);
        }

        private void GetDataLoan_Click(object sender, RoutedEventArgs e)
        {
            Griddo.ItemsSource = CRUD.GetLoans(token);
            Griddo.Items.Refresh();
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
                            id = (Griddo.SelectedItem as LoanHistory).Id,
                            book_Id = (Griddo.SelectedItem as LoanHistory).BookId,
                            user_Id = (uint)(Griddo.SelectedItem as LoanHistory).UserId,
                            startDate = DateFormer((Griddo.SelectedItem as LoanHistory).Date.ToString()),
                            deadline = DateFormer((Griddo.SelectedItem as LoanHistory).DateEnd.ToString()),
                            returned = true,
                            comment = (Griddo.SelectedItem as LoanHistory).Comment
                        };
                        CRUD.PutLoan(token, historyDto.id, historyDto);

                        BorrowUserChangeDto changeDto = new BorrowUserChangeDto()
                        {
                            id = 1
                        };
                        CRUD.BorrowChange(token, historyDto.book_Id, changeDto);

                        Griddo.ItemsSource = CRUD.GetLoans(token);
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
