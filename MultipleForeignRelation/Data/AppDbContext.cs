using Microsoft.EntityFrameworkCore;
using MultipleForeignRelation.Data.Entities;

namespace MultipleForeignRelation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProviderConfig());
            modelBuilder.ApplyConfiguration(new StateConfig());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}
