using Common.IWall.Infrastructure.Configurations.Convertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Common.IWall.Infrastructure.Configurations;

public static class ModelBuilderExtension
{
    public static void SetDefaultDateTimeKind(this ModelBuilder modelBuilder, DateTimeKind kind)
    {
        modelBuilder.UseValueConverterForType<DateTime?>(new DateTimeKindValueConverter(kind));
    }
    private static ModelBuilder UseValueConverterForType<T>(this ModelBuilder modelBuilder, ValueConverter converter)
    {
        return modelBuilder.UseValueConvertorForType(converter, typeof(T));
    }
    private static ModelBuilder UseValueConvertorForType(this ModelBuilder modelBuilder, ValueConverter converter, Type type)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entityType.ClrType.GetProperties().Where(t => t.PropertyType == type);
            foreach (var property in properties)
            {
                modelBuilder.Entity(entityType.Name).Property(property.Name)
                    .HasConversion(converter);
            }

        } 
        return modelBuilder;
    }
}
