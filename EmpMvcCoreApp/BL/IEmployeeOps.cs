using EmpMvcCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpMvcCoreApp.BL
{
    public interface IEmployeeOps
    {
        public Task<List<Employee>> GetEmployeeData();
        public Task<Employee> GetEmployeeDetails(int EmployeeId);
    }
}
