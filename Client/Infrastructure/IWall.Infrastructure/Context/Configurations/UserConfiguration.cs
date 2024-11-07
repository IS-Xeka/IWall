using Common.IWall.Infrastructure.Configurations;
using IWall.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Common.IWall.Infrastructure.Configurations.PropertyBuilderHelper;

namespace IWall.Infrastructure.Context.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(u => u.UserExternalId)
            .IsUnique();

        builder.Property(u => u.UserExternalId)
            .IsRequired()
            .IsGuid();

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(PropertyLengthConstants.Length200);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(PropertyLengthConstants.Length200);

        builder.Property(u => u.IsActived)
            .IsRequired()
            .HasDefaultValue(false);
    }
}
