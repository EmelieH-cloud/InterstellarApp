using InterstellarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterstellarApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()  // konstruktor 
        {

        }

        // properties (DbSet's) 
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<PlanetVisitors> Registrations { get; set; }

        // protected innebär att metoden kan nås av alla inuti klassen och klasser som ärver av klassen.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=USER-PC\\SQLEXPRESS;Database=InterstellarApp;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=True;MultipleActiveResultSets=True;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //--------- Konfigurera many-to-many relationship--------------
            modelBuilder.Entity<PlanetVisitors>()
                .HasKey(pv => new { pv.VisitorId, pv.PlanetId });

            modelBuilder.Entity<PlanetVisitors>()
                .HasOne(pv => pv.Planet)
                .WithMany(p => p.PlanetVisitors)
                .HasForeignKey(pv => pv.PlanetId);

            modelBuilder.Entity<PlanetVisitors>()
                .HasOne(pv => pv.Visitor)
                .WithMany(v => v.PlanetVisitors)
                .HasForeignKey(pv => pv.VisitorId);
            //--------- Konfigurera many-to-many relationship--------------

            //----------------- Data Seeding----------------------------------
            modelBuilder.Entity<Planet>().HasData(
                new Planet { Id = 1, Name = "Earth", Description = "Third planet from the sun", Kilometers = 12742 },
                new Planet { Id = 2, Name = "Mars", Description = "Fourth planet from the sun", Kilometers = 6779 }

            );

            modelBuilder.Entity<Visitor>().HasData(
                new Visitor { Id = 1, Name = "John Doe" },
                new Visitor { Id = 2, Name = "Jane Smith" }

            );

            modelBuilder.Entity<PlanetVisitors>().HasData(
                new PlanetVisitors { PlanetId = 1, VisitorId = 1 },
                new PlanetVisitors { PlanetId = 1, VisitorId = 2 },
                new PlanetVisitors { PlanetId = 2, VisitorId = 2 }

            );
        }
    }
}