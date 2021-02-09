using EmpMvcCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace EmpMvcCoreApp.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await GetEmployeeData();
            ViewData["EmployeeResponse"] = result;
            try
            {
                List<Employee> empList = null;
                if (result != null)
                {
                    EmployeeResponse empResponse =
                       (EmployeeResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(EmployeeResponse));
                    if (empResponse != null)
                    {
                        empList = empResponse.data.ToList<Employee>();
                        
                    }
                }
                ViewData["EmployeeList"] = empList == null? "" : empList;
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            //return HtmlEncoder.Default.Encode($"Hello {name}, ID : {ID}");
            
            
            return View();
        }

        public async Task<string> GetEmployeeData()
        {
            IEnumerable<Employee> empList = new List<Employee>();
            string empData = string.Empty;
            EmployeeResponse empResponse;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://dummy.restapiexample.com/api/v1/employees");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(new HttpRequestMessage());
            if (response.IsSuccessStatusCode)
            {
                empData = await response.Content.ReadAsStringAsync();
                
            }
            return empData;
        }
    }
}
