using Microsoft.EntityFrameworkCore;
using Obras.Commom.Models.AuthorsModels;
using Obras.Repositories.Mapping;

namespace Obras.Repositories.Connection
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        #region Using Fluent API

        public DbSet<FluentAuthors> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorsMap());
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Using Attributes

        // public DbSet<AttributesAuthors> Authors { get; set; }

        #endregion

    }
}
