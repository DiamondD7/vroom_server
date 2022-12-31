using Microsoft.EntityFrameworkCore;
using vroom_server.Model;

namespace vroom_server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
