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
        public DbSet<Archetype> Archetype { get; set; }
        public DbSet<Authority> Authority { get; set; }
        public DbSet<Center> Center { get; set; }
        public DbSet<EnergyType> EnergyType { get; set; }
        public DbSet<ProfileLine> ProfileLine { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<CircuitChannel> CircuitChannels { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<IncarnationCross> IncarnationCrosses { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<DeterminationDigestionVariable> DeterminationDigestionVariables { get; set; }
        public DbSet<EnvironmentVariable> EnvironmentVariables { get; set; }
        public DbSet<CognitionVariable> CognitionVariables { get; set; }
        public DbSet<MotivationVariable> MotivationVariables { get; set; }
        public DbSet<SenseVariable> SenseVariables { get; set; }
        public DbSet<PerspectiveVariable> PerspectiveVariables { get; set; }
        public DbSet<TrajectoryVariable> TrajectoryVariables { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CircuitChannel>()
                .HasKey(cc => new { cc.CircuitId, cc.ChannelId });

            modelBuilder.Entity<CircuitChannel>()
                .HasOne(cc => cc.Circuit)
                .WithMany(c => c.CircuitChannels)
                .HasForeignKey(cc => cc.CircuitId);

            modelBuilder.Entity<CircuitChannel>()
                .HasOne(cc => cc.Channel)
                .WithMany(ch => ch.CircuitChannels)
                .HasForeignKey(cc => cc.ChannelId);

        }
    }
}
