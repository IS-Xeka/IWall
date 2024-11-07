using Microsoft.EntityFrameworkCore;

namespace IWall.Infrastructure.Context
{
    public class IWallDbContext(DbContextOptions<IWallDbContext> options) 
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CustomModelBuilder.OnModelCreating(modelBuilder);
        }
    }
}
