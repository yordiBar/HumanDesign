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
        public DbSet<Location> Locations { get; set; }
        public DbSet<Circuit> Circuits { get; set; }
        public DbSet<Siddhi> Siddhis { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Reactive> Reactives { get; set; }
        public DbSet<Repressive> Repressives { get; set; }
        public DbSet<Shadow> Shadows { get; set; }
    }
}
