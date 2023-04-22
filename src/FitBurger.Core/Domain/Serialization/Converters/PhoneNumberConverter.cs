using System.Text.Json;
using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.Serialization.Converters;

public sealed class PhoneNumberConverter : JsonConverter<PhoneNumber>
{
    public override PhoneNumber Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        if (PhoneNumber.TryParse(value, out var phoneNumber))
        {
            return phoneNumber;
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, PhoneNumber value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}