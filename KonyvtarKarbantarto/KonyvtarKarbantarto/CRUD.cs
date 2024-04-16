using KonyvtarKarbantarto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarKarbantarto
{
    public class CRUD
    {
        Connection connection = new Connection();
        #region UsersCRUD
        string UserURL = "User";
        public List<User> GetUsers(string token)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            return JsonConvert.DeserializeObject<List<User>>(webClient.DownloadString(connection.Url() + UserURL)).ToList();


        }
        #endregion
    }
}
