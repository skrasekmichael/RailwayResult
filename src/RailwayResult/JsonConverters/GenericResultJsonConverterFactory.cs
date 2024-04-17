using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RailwayResult.JsonConverters;

internal sealed class GenericResultJsonConverterFactory : JsonConverterFactory
{
	private static readonly Type GenericResultType = typeof(Result<>);
	private static readonly Type GenericResultConverterType = typeof(GenericResultJsonConverter<>);

	public override bool CanConvert(Type typeToConvert)
	{
		return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == GenericResultType;
	}

	public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
	{
		var nestedType = typeToConvert.GetGenericArguments()[0];
		var converterType = GenericResultConverterType.MakeGenericType(nestedType);
		var flags = BindingFlags.Instance | BindingFlags.Public;
		return Activator.CreateInstance(converterType, flags, null, [options], null) as JsonConverter;
	}
}
