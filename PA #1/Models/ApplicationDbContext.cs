using Microsoft.EntityFrameworkCore;
using PA__1.Models;

namespace PA__1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Bart", LastName = "Simpson", DateOfBirth = new DateTime(1971, 5, 31), GPA = 2.7, Program = "Computer Programmer", Goal = "Become a scientist" },
                new Student { Id = 2, FirstName = "Lisa", LastName = "Simpson", DateOfBirth = new DateTime(1973, 8, 5), GPA = 4.0, Program = "Bachelor of Applied Computer Science", Goal = "Become a musician" }
            );
        }
    }
}
