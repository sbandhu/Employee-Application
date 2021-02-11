using EmpMvcCoreApp.BL;
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
        IEmployeeOps employeeOps;
        public EmployeeController(IEmployeeOps employeeBL)
        {
            employeeOps = employeeBL;
        }

        public async Task<IActionResult> Index()
        {
            
            List<Employee> empList = await employeeOps.GetEmployeeData();
            ViewData["EmployeeList"] = empList == null ? "" : empList;
            
            return View();
        }

        public async Task<IActionResult> Details(int empId)
        {
            Employee employee = await employeeOps.GetEmployeeDetails(empId);
            ViewData["Employee"] = employee == null ? "" : employee;

            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
