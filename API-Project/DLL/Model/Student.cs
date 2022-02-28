using DLL.Interfaces;

namespace DLL.Models
{
    public class Student : ISoftDeletTable
    {
        public int StudentId { get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }
    }
}
