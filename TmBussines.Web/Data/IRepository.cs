using Microsoft.EntityFrameworkCore;
using TmBussines.Web.Data;
using TmBussines.WebTest.Models;

namespace TmBussines.WebServerOffice.Data
{
    public interface IRepository
    {
        IQueryable<TodoItem> TodoItem { get;}

        ApplicationDbContext Context { get; }
    }


    public class Repository : IRepository
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }
        public IQueryable<TodoItem> TodoItem => context.TodoItem;

        public ApplicationDbContext Context
        {
            get { return this.context; }
        }
    }
}
