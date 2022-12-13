using Microsoft.EntityFrameworkCore;
using Tepe.Brt.Data.Entities;

namespace Tepe.Brt.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecommendationEntity>()
                .HasOne<PatientEntity>(s => s.Patient)
                .WithMany(g => g.Recommendations);
        }

        #region Entities
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<RecoItemEntity> RecoItems { get; set; }
        public DbSet<RecommendationEntity> Recommendations { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<MarketEntity> Markets { get; set; }
        #endregion

    }
}
