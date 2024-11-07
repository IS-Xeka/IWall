using Microsoft.EntityFrameworkCore;

namespace Common.IWall.Infrastructure.Configurations;

public interface IDbContextOptionsConfigurator<TContext> where TContext : DbContext
{
    void Configure(DbContextOptionsBuilder<TContext> options);
}
