using System.Diagnostics.CodeAnalysis;

namespace RailwayResult.Helpers;

internal record TypeDefinition(string AssemblyName, string TypeName) : ISpanParsable<TypeDefinition>
{
	public TypeDefinition(Type type) : this(type.Assembly.GetName().Name!, type.FullName!) { }

	public static TypeDefinition Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
	{
		Span<Range> range = stackalloc Range[2];
		s.Split(range, '/');

		var assemblyName = s[range[0]];
		var typeName = s[range[1]];

		return new TypeDefinition(assemblyName.ToString(), typeName.ToString());
	}

	public static TypeDefinition Parse(string s, IFormatProvider? provider) => Parse(s.AsSpan(), provider);

	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out TypeDefinition result)
	{
		result = Parse(s, provider);
		return true;
	}

	public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TypeDefinition result) => TryParse(s.AsSpan(), provider, out result);

	public override string ToString() => $"{AssemblyName}/{TypeName}";
}
