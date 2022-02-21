using Microsoft.EntityFrameworkCore;


namespace DLL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
