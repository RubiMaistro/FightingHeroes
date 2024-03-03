using Microsoft.EntityFrameworkCore;

namespace WebApi.DataObjects
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options) 
            : base(options)
        {
        }
        public DbSet<Hero>? Heroes { get; set; }
        public DbSet<Round>? Rounds { get; set; }
        public DbSet<Battle>? Battles { get; set; }

        public HeroContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
