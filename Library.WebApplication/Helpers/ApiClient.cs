using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApplication.Helpers
{
    public class ApiClient
    {
        string baseUrl = @"http://localhost:49916/api/";

        /// <summary>
        /// Method used to connect with API and get records from database 
        /// </summary>
        /// <typeparam name="T">Generic class</typeparam>
        /// <param name="url">api url</param>
        /// <returns>result and data</returns>
        public T GetData<T>(string url) where T : new()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseTask = client.GetAsync(url);
                responseTask.Wait();
                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return new T();
                var response = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(response);
            }
        }
        /// <summary>
        /// Method used to connect with Api and send information to save in database
        /// </summary>
        /// <typeparam name="T">generic class</typeparam>
        /// <param name="url">api url</param>
        /// <returns>result of successful</returns>
        public bool PostData<T>(string url, T obj) where T : new()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(obj).ToString(),
                    Encoding.UTF8, "application/json");
                var result = client.PostAsync(url, content);

                return result.Result.IsSuccessStatusCode;
            }
        }
    }
}