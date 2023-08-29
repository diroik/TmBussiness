using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics;

namespace TmBussines.WebServerOffice.Data
{
    public class TechmonitorDbContext : DbContext
    {
        public TechmonitorDbContext(DbContextOptions<TechmonitorDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.LogTo(message => Debug.WriteLine(message), new[] { RelationalEventId.CommandExecuted });
        }


        public DbSet<GsmM> GsmM { get; set; }
        public DbSet<AsduTm3Core> AsduTm3Core { get; set; }
        public DbSet<AsduTm3Device> AsduTm3Device { get; set; }

    }

}
