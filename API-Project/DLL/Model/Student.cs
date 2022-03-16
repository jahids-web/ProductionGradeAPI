using DLL.Interfaces;
using DLL.Model;
using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public class Student : ISoftDeletable
    {
        public int StudentId { get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }

        public int DepartmentId { get; set; }

        public DateTimeOffset CreatedAt { get; set ; }
        public string CreatedBy { get; set ; }
        public DateTimeOffset lastUpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public Department Department { get; set; }

        public ICollection<CourseStudent> CourseStudent { get; set; }
    }
}
