/* 
    Name:           Thi Ty Tran
    Date Created:   Dec 12, 2024
    Description:    ASP.NET Razor Pages - Final Assignment
    Last modified:  Dec 14, 2024
 */

using Microsoft.EntityFrameworkCore;

namespace FinalAssignment.Models
{
    // Class representing the database context
    public class MyDbContext : DbContext
    {
        // DbSet for accessing Student entities in the database
        public DbSet<Student> Student { get; set; }

        // Method to configure the database context options
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuring the context to use an in-memory database named "MyDb"
            optionsBuilder.UseInMemoryDatabase("MyDb");
        }
    }
}
