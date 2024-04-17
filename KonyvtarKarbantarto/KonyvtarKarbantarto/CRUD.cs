using KonyvtarBackEnd.Models;
using KonyvtarKarbantarto.Dto;
using KonyvtarKarbantarto.Models;
using KonyvtarKarbantarto.Windows.Felhasznalo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace KonyvtarKarbantarto
{
    public class CRUD
    {
        
        #region UsersCRUD
        
        public static List<User> GetUsers(string token)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return JsonConvert.DeserializeObject<List<User>>(webClient.DownloadString(connection.Url() + "User")).ToList();

        }

        public static string RegisterUser(string token,Register register)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + "Register", "POST", JsonConvert.SerializeObject(register));
        }

        public static string AOEregister(string token,Transfer transfer)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + "AOERegister", "POST", JsonConvert.SerializeObject(transfer));
        }

        public static string PutUser(string token,UserEditDto editenro)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + $"User/{editenro.id}", "PUT", JsonConvert.SerializeObject(editenro));
        }

        public static string PasswordReset(string token,UserPasswordReset passwordReset,uint userid)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + "jelszovaltas/" + userid, "PUT", JsonConvert.SerializeObject(passwordReset));
        }
        #endregion

        #region Rules

        public static List<RulesDto> GetRules(string token)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return JsonConvert.DeserializeObject<List<RulesDto>>(webClient.DownloadString(connection.Url() + "Rule")).ToList();
        }

        #endregion

        #region Profilepic

        public static List<AccountImgDto> GetProfPics(string token)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;


            return JsonConvert.DeserializeObject<List<AccountImgDto>>(webClient.DownloadString(connection.Url() + "GetData")).ToList();
        }

        #endregion

        #region BookCRUD

        public static string PostBooks(string token,BookDto book)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + "Book", "POST", JsonConvert.SerializeObject(book));
        }

        public static List<Book> GetBooks(string token)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return JsonConvert.DeserializeObject<List<Book>>(webClient.DownloadString(connection.Url() + "Book")).ToList();
        }

        public static string PutBook(string token,uint id,BookDtoUpload book)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + $"Book/{id}", "PUT", JsonConvert.SerializeObject(book));
        }

        public static string DeleteBook(string token,uint id)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + $"Book/{id}", "Delete", "");
        }

        #endregion

        #region LoanHistoryCRUD(Borrow stuff included)

        public static string PostLoan(string token,LoanHistoryDto history) {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + "LoanHistory", "POST", JsonConvert.SerializeObject(history));
        }

        public static List<LoanHistory> GetLoans(string token)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return JsonConvert.DeserializeObject<List<LoanHistory>>(webClient.DownloadString(connection.Url() + "LoanHistory")).ToList();
        }

        public static string PutLoan(string token,int id,LoanHistoryDto loan)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + "LoanHistory/" + id, "PUT", JsonConvert.SerializeObject(loan));
        }

        public static string BorrowChange(string token,int id,BorrowUserChangeDto borrow)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + "BorrowUserChange/" + id, "PUT", JsonConvert.SerializeObject(borrow));
        }

        #endregion

        #region APSCRUDS

        #region AuthorCRUD

        public static List<Author> GetAuthors(string token)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return JsonConvert.DeserializeObject<List<Author>>(webClient.DownloadString(connection.Url() + "Author")).ToList();
        }

        #endregion

        #region PublisherCRUD

        public static List<PublisherObject> GetPublisher(string token)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return JsonConvert.DeserializeObject<List<PublisherObject>>(webClient.DownloadString(connection.Url() + "Publisher")).ToList();
        }

        #endregion

        #region SeriesCRUD

        public static List<Series> GetSeries(string token)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return JsonConvert.DeserializeObject<List<Series>>(webClient.DownloadString(connection.Url() + "Series")).ToList();
        }

        #endregion

        public static List<EgyebDto> APSGet(string token,string task)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return JsonConvert.DeserializeObject<List<EgyebDto>>(webClient.DownloadString(connection.Url() + $"{task}")).ToList();
        }

        public static string APSDelete(string token,int id,string task)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + $"{task}/{id}", "Delete", "");
        }

        public static string APSPut(string token,string task,int id,EgyebDto egyebDto)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + $"{task}/{id}", "PUT", JsonConvert.SerializeObject(egyebDto));
        }

        public static string APSPost(string token,string task,EgyebDto egyebDto)
        {
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return webClient.UploadString(connection.Url() + $"{task}", "POST", JsonConvert.SerializeObject(egyebDto));
        }

        #endregion
    }
}
