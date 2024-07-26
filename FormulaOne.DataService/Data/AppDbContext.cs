using Microsoft.EntityFrameworkCore;
using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataService.Data
{
    public class AppDbContext : DbContext
    {
        // define db entities
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // specified relationship between entities 
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.HasOne(a => a.Driver) // a refers to Achievement
                    .WithMany(d => d.Achievements) // d refers to Driver
                    .HasForeignKey(a => a.DriverId) // a refers to Achievement
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Achievement_Driver");
            });
        }
    }
}