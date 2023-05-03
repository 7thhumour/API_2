using Microsoft.EntityFrameworkCore;

namespace APIII.Models
{
    public class AppDbContext:DbContext // AppDbContext allows the db table to be routed and data migration
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options) 
        { 
        }     
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Customer> Customers { get; set; }

        // 1To1 Example (Uncomment code below and run migration to generate tables)
        //public DbSet<TableTwo1to1Ex> TableTwo1to1Ex { get; set; }
        //public DbSet<TableOne1to1Ex> TableOne1to1Ex { get; set; }

        // 1ToM Example (Uncomment code below and run migration to generate tables)
        //public DbSet<TableOne1toManyEx> TableOne1toManyEx { get; set; }
        //public DbSet<TableTwo1toManyEx> TableTwo1toManyEx { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // For the M2M payload (Uncomment code below and run migration to generate tables)
            //modelBuilder.Entity<Trip2>()
            //    .HasMany(t => t.Guides2)
            //    .WithMany(g => g.Trips2)
            //    .UsingEntity<TripGuide2>
            //     (tg => tg.HasOne<Guide2>().WithMany(),
            //      tg => tg.HasOne<Trip2>().WithMany())
            //     .Property(tg => tg.DateConfirmed)
            //     .HasDefaultValueSql("getdate()");
        }
    }
}