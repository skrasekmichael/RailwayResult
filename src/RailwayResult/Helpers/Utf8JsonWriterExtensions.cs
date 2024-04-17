using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RailwayResult.Helpers;

internal static class Utf8JsonWriterExtensions
{
	public static void WriteError(this Utf8JsonWriter writer, Error error, Type valueType, JsonSerializerOptions options)
	{
		var converter = Unsafe.As<JsonConverter<Error>>(options.GetConverter(valueType));
		converter.Write(writer, error, options);
	}
}
