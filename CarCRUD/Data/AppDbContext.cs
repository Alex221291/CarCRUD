using CarCRUD.Models;
using Microsoft.EntityFrameworkCore;
namespace CarCRUD.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Cars> Cars
        {
            get;
            set;
        }
    }
}
