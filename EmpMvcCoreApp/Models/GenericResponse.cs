using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpMvcCoreApp.Models
{
    public class GenericResponse<T>
    {
        public string status { get; set; }
        public T data { get; set; }
        public string message { get; set; }
    }
}
