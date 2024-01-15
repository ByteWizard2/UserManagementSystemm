using Microsoft.EntityFrameworkCore;
using UserM.Models;

namespace UserManagementApp.DataBaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> con) : base(con)
        {
            
        }

        public DbSet<sign> Sign_Up { get; set; }

    

    }
}
