using EdunovaAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace EdunovaAPP.Data
{
    /// <summary>
    /// Ovo mi je datoteka gdje ću navoditi datasetove i načine spajanja u bazi
    /// </summary>
    public class EdunovaContext:DbContext
    {
        /// <summary>
        /// Kostruktor
        /// </summary>
        /// <param name="options"></param>
        public EdunovaContext(DbContextOptions<EdunovaContext> options)
            :base(options)
        {

        }
        /// <summary>
        /// Smjerovi u bazi
        /// </summary>
        public DbSet<Smjer> Smjerovi { get; set; }

        public DbSet<Predavac> Predavaci { get; set; }

        public DbSet<Polaznik> Polaznici { get; set; }

        public DbSet<Grupa> Grupe { get; set; }

        public DbSet<Oznaka> Oznake { get; set; }

        public DbSet<SmjerOznaka> SmjeroviOznake { get; set; }

        public DbSet<Operater> Operateri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // implementacija veze 1:n
            modelBuilder.Entity<Grupa>().HasOne(g => g.Smjer);
            modelBuilder.Entity<Grupa>().HasOne(g => g.Predavac);

            // implementacija veze n:n
            modelBuilder.Entity<Grupa>()
                .HasMany(g => g.Polaznici)
                .WithMany(p => p.Grupe)
                .UsingEntity<Dictionary<string, object>>("clanovi",
                c => c.HasOne<Polaznik>().WithMany().HasForeignKey("polaznik"),
                c => c.HasOne<Grupa>().WithMany().HasForeignKey("grupa"),
                c => c.ToTable("clanovi")
                );

            modelBuilder.Entity<SmjerOznaka>().HasOne(x => x.Smjer);
            modelBuilder.Entity<SmjerOznaka>().HasOne(x => x.Oznaka);

        }
    }
}
