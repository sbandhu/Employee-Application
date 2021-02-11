using EmpMvcCoreApp.Models;
using EmpMvcCoreApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmpMvcCoreApp.BL
{
    public class EmployeeBL : IEmployeeOps
    {
        public async Task<List<Employee>> GetEmployeeData()
        {
            List<Employee> empList = new List<Employee>();
            string empData = string.Empty;
             
            var response = await EmployeeUtil.GetHttpResponse("http://dummy.restapiexample.com/api/v1/employees");
            if (response.IsSuccessStatusCode)
            {
                empData = await response.Content.ReadAsStringAsync();

            }
            if (empData != null)
            {
                empList = EmployeeUtil.JsonToObject<List<Employee>>(empData);
                //EmployeeListResponse empResponse =
                //       (EmployeeListResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(empData, typeof(EmployeeListResponse));
                //if (empResponse != null)
                //{
                //    empList = empResponse.data.ToList<Employee>();

                //}
            }
            return empList;
        }

        public async Task<Employee> GetEmployeeDetails(int EmployeeId)
        {
            Employee employee = new Employee();
            string empData = string.Empty;
            var response = await EmployeeUtil.GetHttpResponse("http://dummy.restapiexample.com/api/v1/employee/"+ EmployeeId.ToString());
            if (response.IsSuccessStatusCode)
            {
                empData = await response.Content.ReadAsStringAsync();

            }
            if (empData != null)
            {
                employee = EmployeeUtil.JsonToObject<Employee>(empData);
                //EmployeeResponse empResponse =
                //       (EmployeeResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(empData, typeof(EmployeeResponse));
                //if (empResponse != null)
                //{
                //    employee = (Employee) empResponse.data;

                //}
            }
                return employee;
        }
    }
}
