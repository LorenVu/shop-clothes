using System.Text.Json;
using System.Text.Json.Serialization;
using BuildingBlock.Shared.Contracts.ValueObjects;

namespace Clothes.Domain.Extensions;

public class MyDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.Parse(reader.GetString() ?? string.Empty);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(SystemConstant.SystemFormatDatetime));
    }
}