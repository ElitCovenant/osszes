using KonyvtarKarbantarto.Dto;
using KonyvtarKarbantarto.Models;
using KonyvtarKarbantarto.Windows.Felhasznalo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
    }
}
