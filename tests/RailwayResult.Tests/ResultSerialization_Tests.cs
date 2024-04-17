using System.Text.Json;

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
		json.Should().Be(expectedJson);
	}

	[Fact]
	public void FailureResult_Should_SerializeWithErrorTypeAndValue()
	{
		//arrange
		var result = new Result(BasicError.ErrorA);
		var expectedJson = """{"Type":"RailwayResult.Tests/RailwayResults.Tests.Mocks.BasicError","Error":{"Key":"Key","Message":"Error A"}}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.Should().Be(expectedJson);
	}

	[Fact]
	public void FailureResult_WithComplexError_Should_SerializeWithErrorTypeAndValueIncludingAdditionalData()
	{
		//arrange
		var result = new Result(ComplexError.One);
		var expectedJson = """{"Type":"RailwayResult.Tests/RailwayResults.Tests.Mocks.ComplexError","Error":{"AdditionalString":"one","AdditionalInt":1,"Record":{"A":2,"B":"two"},"Records":[{"A":3,"B":"three"},{"A":4,"B":"four"}],"Key":"key","Message":"msg"}}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.Should().Be(expectedJson);
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
		json.Should().Be(expectedJson);
	}

	[Fact]
	public void GenericSuccessResult_WithComplexValue_Should_SerializeWithValue()
	{
		//arrange
		Result<ComplexType> result = ComplexType.Data1A2B3C;
		var expectedJson = """{"Value":{"Data":"Data","Int":0,"Record":{"A":1,"B":"A"},"Records":[{"A":2,"B":"B"},{"A":3,"B":"C"}]}}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.Should().Be(expectedJson);
	}

	[Fact]
	public void GenericFailureResult_Should_SerializeWithErrorTypeAndValue()
	{
		//arrange
		Result<string> result = BasicError.ErrorA;
		var expectedJson = """{"ErrorType":"RailwayResult.Tests/RailwayResults.Tests.Mocks.BasicError","Error":{"Key":"Key","Message":"Error A"}}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.Should().Be(expectedJson);
	}

	[Fact]
	public void GenericFailureResult_WithComplexError_Should_SerializeWithErrorTypeAndValueIncludingAdditionalData()
	{
		//arrange
		Result<string> result = ComplexError.One;
		var expectedJson = """{"ErrorType":"RailwayResult.Tests/RailwayResults.Tests.Mocks.ComplexError","Error":{"AdditionalString":"one","AdditionalInt":1,"Record":{"A":2,"B":"two"},"Records":[{"A":3,"B":"three"},{"A":4,"B":"four"}],"Key":"key","Message":"msg"}}""";

		//act
		var json = JsonSerializer.Serialize(result);

		//assert
		json.Should().Be(expectedJson);
	}
}
