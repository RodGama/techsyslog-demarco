using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using Web.TechsysLog.Models;

namespace Web.TechsysLog.FormData
{
    public class FormSenderSignUp
    {
        public static async Task SendFormAsync(System.Collections.Specialized.NameValueCollection form)
        {
            var client = new HttpClient();
            var signUpObj = new SignUpModel(form["fname"], form["email"], form["password"], form["passwordc"], 1); 
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri("https://localhost:7050/api/v1/User/Add"),

                Content = new StringContent(JsonConvert.SerializeObject(signUpObj))
                {
                    Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}