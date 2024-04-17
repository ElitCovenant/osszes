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
    public partial class KonyvSzerkeszto : Window
    {
        string token;
        string PicPath;
        Book oo = new Book();
        public KonyvSzerkeszto(string tok, Book ook)
        {
            token = tok;
            oo = ook;
            InitializeComponent();
            WarhNum.Text = ook.WarehouseNum.ToString();
            Ev.Text = ook.PurchaseDate.ToString().Split('.')[0].Replace('.', ' ').Trim();
            Honap.Text = ook.PurchaseDate.ToString().Split('.')[1].Replace('.', ' ').Trim();
            Nap.Text = ook.PurchaseDate.ToString().Split('.')[2].Replace('.', ' ').Trim();
            Title.Text = ook.Title.ToString();
            Isbnnum.Text = ook.IsbnNum.ToString();
            NobleNote.Text = ook.Szakkjelzet.ToString();
            CutterSign.Text = ook.CutterJelzet.ToString();
            Releasedate.Text = ook.ReleaseDate.ToString();
            Price.Text = ook.Price.ToString();
            Comment.Text = ook.Comment;
            Picture.Text = ook.BookImg.ToString();

            List<Author> authors = CRUD.GetAuthors(token);

            for (int i = 0; i < authors.Count; i++)
            {
                AuthorId.Items.Add(authors[i].Id + "-" + authors[i].Name);
                if (authors[i].Id == ook.AuthorId)
                {
                    AuthorId.SelectedIndex = i;
                }
            }

            List<Series> seriesList = CRUD.GetSeries(token);
            for (int i = 0; i < seriesList.Count; i++)
            {
                Series.Items.Add(seriesList[i].Id + "-" + seriesList[i].Name);
                if (seriesList[i].Id == ook.SeriesId)
                {
                    Series.SelectedIndex = i;
                }
            }
            Series.SelectedIndex = 0;

            List<PublisherObject> publishers = CRUD.GetPublisher(token);
            for (int i = 0; i < publishers.Count; i++)
            {
                PublisherId.Items.Add(publishers[i].Id + "-" + publishers[i].Name);
                if (publishers[i].Id == ook.PublisherId)
                {
                    PublisherId.SelectedIndex = i;
                }
            }
            PublisherId.SelectedIndex = 0;
        }

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
            if (int.TryParse(c.Trim(), out int g))
            {
                if (g < 10 && !c.Contains('0'))
                {
                    return "0" + c;
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
                BookDtoUpload book = new BookDtoUpload();

                book.warehouse_Num = Securer(WarhNum.Text);
                book.purchase_Date = SecurerDate(Ev.Text).ToString() + "-" + SecurerDate(Honap.Text).ToString() + "-" + SecurerDate(Nap.Text).ToString();
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
                book.user_Id = (uint)oo.UserId;
                book.bookImg = Picture.Text;
                MessageBox.Show(CRUD.PutBook(token, oo.Id, book));
                PicPath = null;
                book = new BookDtoUpload();
            }
            catch (Exception p)
            {

                MessageBox.Show("Error! :" + p.Message);
            }
        }

    }
}
