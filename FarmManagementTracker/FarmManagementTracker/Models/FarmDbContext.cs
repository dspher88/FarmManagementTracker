using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmManagementTracker.Models
{
    public class FarmDbContext : IdentityDbContext
    {
        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<SupplyItem> SupplyItems { get; set; }
        public DbSet<FarmTask> FarmTasks { get; set; }
        public DbSet<VaccinationRecord> VaccinationRecords { get; set; }
        public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set up Animal-Vaccination relationship with navigation property
            modelBuilder.Entity<VaccinationRecord>()
                .HasOne(v => v.Animal)
                .WithMany()
                .HasForeignKey(v => v.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Animals
            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    Id = 1,
                    Name = "Ace",
                    Type = "Chicken",
                    Breed = "Brahma",
                    Gender = "Male",
                    BirthDate = new DateTime(2024, 10, 16),
                    Status = "Active",
                    Notes = "Leader of the flock"
                },
                new Animal
                {
                    Id = 2,
                    Name = "Waddles",
                    Type = "Duck",
                    Breed = "Khaki Campbell",
                    Gender = "Male",
                    BirthDate = new DateTime(2023, 4, 16),
                    Status = "Active",
                    Notes = "Eats a lot"
                },
                new Animal
                {
                    Id = 3,
                    Name = "Rosie",
                    Type = "Chicken",
                    Breed = "Rhode Island Red",
                    Gender = "Female",
                    BirthDate = new DateTime(2025, 1, 16),
                    Status = "Active",
                    Notes = "Calm and productive"
                },
                new Animal
                {
                    Id = 4,
                    Name = "Quackers",
                    Type = "Duck",
                    Breed = "Runner Duck",
                    Gender = "Female",
                    BirthDate = new DateTime(2025, 2, 16),
                    Status = "Active",
                    Notes = "Very vocal"
                }
            );

            // Seed Supplies
            modelBuilder.Entity<SupplyItem>().HasData(
                new SupplyItem
                {
                    Id = 1,
                    Name = "Layer Pellets",
                    Category = "Feed",
                    Quantity = 3,
                    Unit = "bags",
                    Notes = "Buy more if under 2"
                },
                new SupplyItem
                {
                    Id = 2,
                    Name = "Straw Bales",
                    Category = "Bedding",
                    Quantity = 5,
                    Unit = "bales",
                    Notes = "Used for coop bedding"
                }
            );

            // Seed Tasks
            modelBuilder.Entity<FarmTask>().HasData(
                new FarmTask
                {
                    Id = 1,
                    TaskName = "Clean Chicken Coop",
                    Frequency = "Weekly",
                    NextDueDate = new DateTime(2025, 5, 6),
                    Notes = "Use pine shavings"
                },
                new FarmTask
                {
                    Id = 2,
                    TaskName = "Refill Waterers",
                    Frequency = "Daily",
                    NextDueDate = new DateTime(2025, 4, 30),
                    Notes = "Done every morning"
                }
            );
        }
    }
}




