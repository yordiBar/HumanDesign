using HumanDesign.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Gate> Gates { get; set; }
    }
}
