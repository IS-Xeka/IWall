using Common.IWall.Infrastructure.Configurations;
using IWall.Infrastructure.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IWall.Infrastructure.Context;

public static class CustomModelBuilder
{
    public static void OnModelCreating(ModelBuilder modelBuilder)
    {
        //ConfigureForecastModels(modelBuilder);
        modelBuilder.SetDefaultDateTimeKind(DateTimeKind.Utc);
    }
    private static void ConfigureForecastModels(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid");

        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
