namespace Football_Tournament.Data
{
    using Football_Tournament.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class TournamentDbContext : DbContext
    {
        public TournamentDbContext(DbContextOptions<TournamentDbContext> options)
            : base(options)
        {

        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }

        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Team>()
                .HasOne(t => t.Group)
                .WithMany(g => g.Teams)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Group>()
                .HasOne(g => g.Tournament)
                .WithMany(t => t.Groups)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }

    }
}
