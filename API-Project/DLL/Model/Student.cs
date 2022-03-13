using DLL.Interfaces;
using System;

namespace DLL.Models
{
    public class Student : ISoftDeletable,ITrackable
    {
        public int StudentId { get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }

        
        public DateTimeOffset CreatedAt { get; set ; }
        public string CreatedBy { get; set ; }
        public DateTimeOffset lastUpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

 
    }
}
