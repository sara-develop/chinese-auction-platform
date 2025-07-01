using WebAPI_project.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_project.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Donor> Donors { get; set; }
    }

}
