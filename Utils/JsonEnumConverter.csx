using System;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

public class JsonEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
{
    public override TEnum Read(ref Utf8JsonReader reader, Type typeConvert, JsonSerializerOptions options)
    {
        string value = reader.GetString();

        foreach (var field in typeof(TEnum).GetFields())
        {
            if (field.GetCustomAttribute<DescriptionAttribute>() is DescriptionAttribute attribute
            && attribute.Description.Equals(value, StringComparison.OrdinalIgnoreCase))
                return (TEnum)field.GetValue(null);
        }

        throw new JsonException($"Value {value} could not be converted to {typeof(TEnum).Name}");
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        var field = value.GetType().GetField(value.ToString());

        if (field?.GetCustomAttribute<DescriptionAttribute>() is DescriptionAttribute attribute)
            writer.WriteStringValue(attribute.Description);
        else
            writer.WriteStringValue(value.ToString());
    }
}