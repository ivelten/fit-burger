using System.Text.Json;
using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.ValueObjects.Serialization.Converters;

public sealed class EmailConverter : JsonConverter<Email>
{
    public override Email Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        if (Email.TryParse(value, out var email))
        {
            return email;
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, Email value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}