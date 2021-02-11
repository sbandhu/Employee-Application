using EmpMvcCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmpMvcCoreApp.Utilities
{
    public class EmployeeUtil
    {
        public static async Task<HttpResponseMessage> GetHttpResponse(string Url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(new HttpRequestMessage());
            return response;
        }

        public static T JsonToObject<T>(string jsonString)
        {
            T temp = default(T);
            GenericResponse<T> response =
                       (GenericResponse<T>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(GenericResponse<T>));
            if (response != null)
            {
                temp = (T)response.data;

            }
            return temp;
        }
    }
}
