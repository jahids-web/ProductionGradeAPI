﻿using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Model
{
    public class Course : ISoftDeletable
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }    
        public decimal Credit { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset lastUpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<CourseStudent> CoursesStudent { get; set; }
    }
}
