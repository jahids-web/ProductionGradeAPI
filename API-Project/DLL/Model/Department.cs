using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string  Code { get; set; }

        internal List<Department> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
