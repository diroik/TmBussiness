using Microsoft.EntityFrameworkCore;

namespace TmBussines.WebServerOffice.Data
{
    public interface IRepository
    {
        IQueryable<GsmM> GsmM { get;}
        IQueryable<AsduTm3Core> AsduTm3Core { get; }
        IQueryable<AsduTm3Device> AsduTm3Device { get; }

        TechmonitorDbContext Context { get; }
    }


    public class Repository : IRepository
    {
        private readonly TechmonitorDbContext context;

        public Repository(TechmonitorDbContext ctx)
        {
            this.context = ctx;
        }
        public IQueryable<GsmM> GsmM => context.GsmM;
        public IQueryable<AsduTm3Core> AsduTm3Core => context.AsduTm3Core;
        public IQueryable<AsduTm3Device> AsduTm3Device => context.AsduTm3Device;

        public TechmonitorDbContext Context
        {
            get { return this.context; }
        }
    }
}
