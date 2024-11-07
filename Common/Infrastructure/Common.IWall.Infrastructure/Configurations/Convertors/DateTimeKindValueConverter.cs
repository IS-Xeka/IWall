using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Common.IWall.Infrastructure.Configurations.Convertors;

public class DateTimeKindValueConverter(DateTimeKind kind, ConverterMappingHints converterMappingHints = null)
    : ValueConverter<DateTime, DateTime>(
        v => v.ToUniversalTime(),
        v => DateTime.SpecifyKind(v, kind), converterMappingHints)
{

}