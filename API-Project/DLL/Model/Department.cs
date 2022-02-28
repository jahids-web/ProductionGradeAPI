using DLL.Interfaces;
using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public class Department : ISoftDeletTable
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
