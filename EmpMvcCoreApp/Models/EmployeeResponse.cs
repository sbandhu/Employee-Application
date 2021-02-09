using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpMvcCoreApp.Models
{
    public class EmployeeResponse
    {
        public string status { get; set; }
        public IEnumerable<Employee> data { get; set; }
        public string message { get; set; }
    }
}
