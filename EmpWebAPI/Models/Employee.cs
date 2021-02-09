using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpWebAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public Employee()
        {

        }
        public Employee(int EmpId, string Name)
        {
            this.EmployeeId = EmpId;
            this.Name = Name;
        }

    }
}
