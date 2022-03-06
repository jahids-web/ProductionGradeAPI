using DLL.Interfaces;
using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public class Department:ISoftDeletable,ITrackable
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string  Code { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset lastUpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<Student> Student { get; set; }





      
    }
}
