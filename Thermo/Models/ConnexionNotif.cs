using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Thermo.Models
{
    public class ConnexionNotif
    {
        public static string url = "http://localhost/Witrack/";
        private static ConnexionNotif instance;
        public static HttpClient client;
        public static HttpClientHandler handler;

        public static ConnexionNotif Instance
        {
            get
            {
                if (ConnexionNotif.instance == null)
                    ConnexionNotif.instance = new ConnexionNotif();
                return ConnexionNotif.instance;
            }
        }

        static ConnexionNotif()
        {
        }

        public ConnexionNotif()
        {
            ConnexionNotif.handler = new HttpClientHandler();
            ConnexionNotif.client = new HttpClient((HttpMessageHandler)ConnexionNotif.handler);
            ConnexionNotif.client.Timeout = TimeSpan.FromSeconds(12.0);
            ConnexionNotif.client.BaseAddress = new Uri(ConnexionNotif.url);
            ConnexionNotif.client.DefaultRequestHeaders.Accept.Clear();
            ConnexionNotif.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static bool Session_Opned()
        {
            return false;
        }
    }
}