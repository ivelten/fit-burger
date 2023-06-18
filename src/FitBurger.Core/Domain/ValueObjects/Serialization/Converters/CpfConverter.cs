using System.Text.Json;
using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.ValueObjects.Serialization.Converters;

public sealed class CpfConverter : JsonConverter<Cpf>
{
    public override Cpf Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        if (Cpf.TryParse(value, out var cpf)) return cpf;

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, Cpf value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}