using System.Text.Json;
using System.Text.Json.Serialization;

using RailwayResult.Helpers;

namespace RailwayResult.JsonConverters;

internal sealed class ResultJsonConverter : JsonConverter<Result>
{
	internal const string JSON_ERROR_TYPE = "Type";
	internal const string JSON_ERROR = "Error";

	public override Result? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.StartObject)
		{
			throw new JsonException("Expected '{'.");
		}

		var name = reader.ReadPropertyName(JSON_ERROR_TYPE, JSON_ERROR);
		Result? result;

		if (name == JSON_ERROR_TYPE)
		{
			var errorType = reader.ReadErrorType("Expected error type definition.");

			reader.ReadPropertyName(JSON_ERROR);
			var error = reader.ReadError(errorType, options);

			result = new(error);
		}
		else
		{
			reader.ReadOrThrow(JsonTokenType.Null, "Expected null, failure Result has to have specified error type.");
			result = Result.Success;
		}

		reader.ReadOrThrow(JsonTokenType.EndObject, "Expected '}'.");
		return result;
	}

	public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
	{
		writer.WriteStartObject();

		if (value.IsSuccess)
		{
			writer.WritePropertyName(JSON_ERROR);
			writer.WriteNullValue();
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
