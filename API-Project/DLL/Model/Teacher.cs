using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Model
{
    public class Teacher : ISoftDeletable
    {
        public int TeacherId { get; set; }  
        public string TeacherName { get; set; }
        public string TeacherType { get; set; }
        public string TeacherEmail { get; set; }    

        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset lastUpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
