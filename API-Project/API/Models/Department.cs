using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Department
    {
        public string Name { get; set; }
        public string  Code { get; set; }

        internal List<Department> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
