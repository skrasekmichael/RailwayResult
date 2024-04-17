using System.Text.Json;
using System.Text.Json.Serialization;

using RailwayResult.Helpers;

namespace RailwayResult.JsonConverters;

internal sealed class GenericResultJsonConverter<T> : JsonConverter<Result<T>>
{
	internal const string JSON_VALUE = "Value";
	internal const string JSON_ERROR_TYPE = "ErrorType";
	internal const string JSON_ERROR = "Error";

	private static readonly Type ValueType = typeof(T);

	private readonly JsonConverter<T> _valueConverter;

	public GenericResultJsonConverter(JsonSerializerOptions options)
	{
		_valueConverter = (JsonConverter<T>)options.GetConverter(typeof(T));
	}

	public override Result<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.StartObject)
		{
			throw new JsonException("Expected '{'.");
		}

		var name = reader.ReadPropertyName(JSON_ERROR_TYPE, JSON_VALUE);
		Result<T>? result;

		if (name == JSON_ERROR_TYPE)
		{
			var errorType = reader.ReadErrorType("Expected error type definition.");

			reader.ReadPropertyName(JSON_ERROR);
			var error = reader.ReadError(errorType, options);

			result = new(error);
		}
		else
		{
			reader.Read();
			result = _valueConverter.Read(ref reader, ValueType, options);
		}

		reader.ReadOrThrow(JsonTokenType.EndObject, "Expected '}'.");
		return result;
	}

	public override void Write(Utf8JsonWriter writer, Result<T> value, JsonSerializerOptions options)
	{
		writer.WriteStartObject();

		if (value!.IsSuccess)
		{
			writer.WritePropertyName(JSON_VALUE);
			_valueConverter.Write(writer, value.Value, options);
		}
		else
		{
			var errorType = value.Error.GetType();
			writer.WriteString(JSON_ERROR_TYPE, new TypeDefinition(errorType).ToString());

			writer.WritePropertyName(JSON_ERROR);
			writer.WriteError(value.Error, errorType, options);
		}

		writer.WriteEndObject();
	}
}
