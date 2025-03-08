using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RailwayResult.Helpers;

internal static class Utf8JsonReaderExtensions
{
	public static void ReadOrThrow(ref this Utf8JsonReader reader, JsonTokenType type, string? errorMessage = null)
	{
		reader.Read();
		if (reader.TokenType != type)
		{
			throw new JsonException(errorMessage);
		}
	}

	public static string? ReadPropertyName(ref this Utf8JsonReader reader, params string[] expectedParams)
	{
		reader.Read();
		var name = reader.GetString();
		if (reader.TokenType != JsonTokenType.PropertyName || !expectedParams.Contains(name))
		{
			throw new JsonException($"Expected one of '{string.Join("', '", expectedParams)}'.");
		}

		return name;
	}

	public static void ReadPropertyName(ref this Utf8JsonReader reader, string expectedPropertyName)
	{
		reader.Read();
		var name = reader.GetString();
		if (reader.TokenType != JsonTokenType.PropertyName || name != expectedPropertyName)
		{
			throw new JsonException($"Expected property '{expectedPropertyName}'.");
		}
	}

	public static string ReadStringValue(ref this Utf8JsonReader reader, string? errorMessage = null)
	{
		reader.Read();
		if (reader.TokenType != JsonTokenType.String)
		{
			throw new JsonException(errorMessage);
		}

		return reader.GetString()!;
	}

	public static Type ReadErrorType(ref this Utf8JsonReader reader, string? errorMessage = null)
	{
		reader.Read();
		if (reader.TokenType != JsonTokenType.String)
		{
			throw new JsonException(errorMessage);
		}

		var typeDefinitionString = reader.GetString()!;
		var typeDefinition = TypeDefinition.Parse(typeDefinitionString, default);

		try
		{
			var assembly = Assembly.Load(typeDefinition.AssemblyName);
			return assembly.GetType(typeDefinition.TypeName)
				?? throw new JsonException($"Failed to load error type [{typeDefinitionString}].");
		}
		catch
		{
			throw new JsonException($"Failed to load error type [{typeDefinitionString}].");
		}
	}

	public static Error ReadError(ref this Utf8JsonReader reader, Type valueType, JsonSerializerOptions options)
	{
		reader.Read();
		var converter = Unsafe.As<JsonConverter<Error>>(options.GetConverter(valueType));
		return converter.Read(ref reader, valueType, options)
			?? throw new JsonException($"Failed to deserialize error type [{valueType}].");
	}
}
