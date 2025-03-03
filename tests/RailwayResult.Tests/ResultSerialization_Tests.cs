using System.Text.Json;
using System.Text.RegularExpressions;

using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

using RailwayResult.Tests.Mocks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RailwayResult.Tests;

public sealed class ResultSerialization_Tests
{
	[Fact]
	public void SuccessResult_Should_SerializeWithNullError()
	{
		//arrange
		var result = Result.Success;
		var expectedJson = """{"Error":null}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.ShouldBe(expectedJson);
	}

	[Fact]
	public void FailureResult_Should_SerializeWithErrorTypeAndValue()
	{
		//arrange
		var result = new Result(BasicError.ErrorA);
		var expectedJson = """{"Type":"RailwayResult.Tests/RailwayResult.Tests.Mocks.BasicError","Error":{"Key":"Key","Message":"Error A"}}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.ShouldBe(expectedJson);
	}

	[Fact]
	public void FailureResult_WithComplexError_Should_SerializeWithErrorTypeAndValueIncludingAdditionalData()
	{
		//arrange
		var result = new Result(ComplexError.One);
		var expectedJson = """{"Type":"RailwayResult.Tests/RailwayResult.Tests.Mocks.ComplexError","Error":{"AdditionalString":"one","AdditionalInt":1,"Record":{"A":2,"B":"two"},"Records":[{"A":3,"B":"three"},{"A":4,"B":"four"}],"Key":"key","Message":"msg"}}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.ShouldBe(expectedJson);
	}

	[Fact]
	public void GenericSuccessResult_Should_SerializeWithValue()
	{
		//arrange
		Result<string> result = "aloha";
		var expectedJson = """{"Value":"aloha"}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.ShouldBe(expectedJson);
	}

	[Fact]
	public void GenericSuccessResult_WithComplexValue_Should_SerializeWithValue()
	{
		//arrange
		Result<ComplexType> result = ComplexType.Data1A2B3C;
		var expectedJson = """{"Value":{"Data":"Data","Int":0,"Record":{"Index":1,"Letter":"A"},"Records":[{"Index":2,"Letter":"B"},{"Index":3,"Letter":"C"}]}}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.ShouldBe(expectedJson);
	}

	[Fact]
	public void GenericFailureResult_Should_SerializeWithErrorTypeAndValue()
	{
		//arrange
		Result<string> result = BasicError.ErrorA;
		var expectedJson = """{"ErrorType":"RailwayResult.Tests/RailwayResult.Tests.Mocks.BasicError","Error":{"Key":"Key","Message":"Error A"}}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.ShouldBe(expectedJson);
	}

	[Fact]
	public void GenericFailureResult_WithComplexError_Should_SerializeWithErrorTypeAndValueIncludingAdditionalData()
	{
		//arrange
		Result<string> result = ComplexError.One;
		var expectedJson = """{"ErrorType":"RailwayResult.Tests/RailwayResult.Tests.Mocks.ComplexError","Error":{"AdditionalString":"one","AdditionalInt":1,"Record":{"A":2,"B":"two"},"Records":[{"A":3,"B":"three"},{"A":4,"B":"four"}],"Key":"key","Message":"msg"}}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.ShouldBe(expectedJson);
	}

	[Fact]
	public void GenericResult_WithGenericError_Should_SerializeWithWithGenericErrorTypeIncludingAdditionalData()
	{
		//arrange
		Result<string> result = GenericError<int>.GenericErrorA;
		var expectedJson = """{"ErrorType":"RailwayResult.Tests/RailwayResult.Tests.Mocks.GenericError\u00601[[System.Int32, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]","Error":{"Data":100,"Key":"A","Message":"Error A"}}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.ShouldBe(expectedJson);
	}
}
