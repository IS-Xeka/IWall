﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Common.IWall.Infrastructure.Configurations.Configurator;

public abstract class BaseDbContextConfigurator<TDbContext>(
    IConfiguration configuration,
    ILoggerFactory loggerFactory
    ) : IDbContextOptionsConfigurator<TDbContext> where TDbContext : DbContext
{
    protected abstract string ConnectionStringName { get; }
    public void Configure(DbContextOptionsBuilder<TDbContext> options)
    {
        var connectionString = configuration.GetConnectionString( ConnectionStringName );
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException($"Не удалось найти строку подключения {connectionString}");
        }
        options.UseLoggerFactory(loggerFactory)
            .UseNpgsql(connectionString, t => { t.CommandTimeout(commandTimeout: 60); });
    }
}
