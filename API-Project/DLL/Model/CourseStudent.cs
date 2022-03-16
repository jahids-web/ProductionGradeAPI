using DLL.Interfaces;
using DLL.Models;

namespace DLL.Model
{
    public class CourseStudent : ISoftDeletable
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }  
        public int StudentId { get; set; }  
        public Student Student { get; set; }

    }
}
