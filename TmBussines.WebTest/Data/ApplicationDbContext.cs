using Microsoft.EntityFrameworkCore;
using TmBussines.WebTest.Models;

namespace TmBussines.WebTest.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItem { get; set; }

    }
}
