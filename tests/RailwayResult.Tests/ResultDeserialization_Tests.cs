using System.Text.Json;

using RailwayResult.Tests.Extensions;

namespace RailwayResult.Tests;

public sealed class ResultDeserialization_Tests
{
	[Fact]
	public void SerializedSuccessResult_Should_BeDeserializedAsSameResult()
	{
		//arrange
		var json = """{"Error":null}""";
		var expectedResult = Result.Success;

		//act
		var result = JsonSerializer.Deserialize<Result>(json);

		//assert
		result!.ShouldBe(expectedResult);
	}

	[Fact]
	public void SerializedFailureResult_Should_BeDeserializedAsSameResult()
	{
		//arrange
		var json = """{"Type":"RailwayResult.Tests/RailwayResults.Tests.Mocks.BasicError","Error":{"Key":"Key","Message":"Error A"}}""";
		var expectedResult = new Result(BasicError.ErrorA);

		//act
		var result = JsonSerializer.Deserialize<Result>(json);

		//assert
		result!.ShouldBe(expectedResult);
	}

	[Fact]
	public void SerializedFailureResult_WithComplexError_Should_BeDeserializedAsSameResult()
	{
		//arrange
		var json = """{"Type":"RailwayResult.Tests/RailwayResults.Tests.Mocks.ComplexError","Error":{"AdditionalString":"one","AdditionalInt":1,"Record":{"A":2,"B":"two"},"Records":[{"A":3,"B":"three"},{"A":4,"B":"four"}],"Key":"key","Message":"msg"}}""";
		var expectedResult = new Result(ComplexError.One);

		//act
		var result = JsonSerializer.Deserialize<Result>(json);

		//assert
		result!.ShouldBe(expectedResult);
	}

	[Fact]
	public void SerializedGenericSuccessResult_Should_BeDeserializedAsSameResult()
	{
		//arrange
		var json = """{"Value":"aloha"}""";
		Result<string> expectedResult = "aloha";

		//act
		var result = JsonSerializer.Deserialize<Result<string>>(json);

		//assert
		result!.ShouldBe(expectedResult);
	}

	[Fact]
	public void SerializedGenericSuccessResult_WithComplexValue_Should_BeDeserializedAsSameResult()
	{
		//arrange
		var json = """{"Value":{"Data":"Data","Int":0,"Record":{"A":1,"B":"A"},"Records":[{"A":2,"B":"B"},{"A":3,"B":"C"}]}}""";
		Result<ComplexType> expectedResult = ComplexType.Data1A2B3C;

		//act
		var result = JsonSerializer.Deserialize<Result<ComplexType>>(json);

		//assert
		result!.ShouldBe(expectedResult);
	}

	[Fact]
	public void SerializedGenericFailureResult_Should_BeDeserializedAsSameResult()
	{
		//arrange
		var json = """{"ErrorType":"RailwayResult.Tests/RailwayResults.Tests.Mocks.BasicError","Error":{"Key":"Key","Message":"Error A"}}""";
		Result<string> expectedResult = BasicError.ErrorA;

		//act
		var result = JsonSerializer.Deserialize<Result<string>>(json);

		//assert
		result!.ShouldBe(expectedResult);
	}

	[Fact]
	public void SerializedGenericFailureResult_WithComplexError_Should_BeDeserializedAsSameResult()
	{
		//arrange
		var json = """{"ErrorType":"RailwayResult.Tests/RailwayResults.Tests.Mocks.ComplexError","Error":{"AdditionalString":"one","AdditionalInt":1,"Record":{"A":2,"B":"two"},"Records":[{"A":3,"B":"three"},{"A":4,"B":"four"}],"Key":"key","Message":"msg"}}""";
		Result<string> expectedResult = ComplexError.One;

		//act
		var result = JsonSerializer.Deserialize<Result<string>>(json);

		//assert
		result!.ShouldBe(expectedResult);
	}
}
