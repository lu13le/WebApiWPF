using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Posao
{
    public class ApiHelper
    {
        public static HttpClient client { get; set; }
        public static void InitializeClient()
        {
            var username = "desktopapp";
            var pass = "ThePa55word";
            var base64 = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{pass}"));
            client = new HttpClient();
            
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",base64);
            
        }



    }
}
