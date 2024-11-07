using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.IWall.Infrastructure.Configurations;

public static class PropertyBuilderHelper
{
    public static PropertyBuilder<Guid> IsGuid(this PropertyBuilder<Guid> builder)
    {
        return builder.HasColumnType("uuid");
    }

    public readonly struct PropertyLengthConstants
    {
        public static readonly int Length200 = 200;
    }
}
