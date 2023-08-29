using Microsoft.EntityFrameworkCore;
using TmBussines.WebMvcTest.Models;

namespace TmBussines.WebMvcTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<TodoItem> TodoItem { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem()
                {
                    Id = 1,
                    Name = "Meeting with managment",
                    IsComplete = true,
                    Description = "In Meeting need to discuss some points."
                },
                new TodoItem()
                {
                    Id = 2,
                    Name = "Go for shopping",
                    IsComplete = false,
                    Description = "List of this item buy."
                },
                new TodoItem()
                {
                    Id = 3,
                    Name = "Call to some one for do some task",
                    IsComplete = true,
                    Description = "Here task to ask to do on call."
                });
        }
    }
}
