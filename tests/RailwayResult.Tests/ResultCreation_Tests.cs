namespace RailwayResult.Tests;

public sealed class ResultCreation_Tests
{
	[Fact]
	public void Result_FromError_Should_ReturnSameResult_AsCtor()
	{
		//arrange
		var expectedResult = new Result(BasicError.ErrorA);

		//act
		var result = Result.FromError(BasicError.ErrorA);

		//assert
		result.IsSuccess.Should().Be(expectedResult.IsSuccess);
		result.Error.Should().BeEquivalentTo(expectedResult.Error);
	}

	[Fact]
	public void GenericResult_FromError_Should_ReturnSameResult_AsCtor()
	{
		//arrange
		var expectedResult = new Result<string>(BasicError.ErrorA);

		//act
		var result = Result<string>.FromError(BasicError.ErrorA);

		//assert
		result.IsSuccess.Should().Be(expectedResult.IsSuccess);
		result.Error.Should().BeEquivalentTo(expectedResult.Error);
	}

	[Fact]
	public void GenericResult_FromValue_Should_ReturnSameResult_AsCtor()
	{
		//arrange
		var expectedResult = Result<string>.Success("100");

		//act
		var result = Result<string>.FromValue("100");

		//assert
		result.IsSuccess.Should().Be(expectedResult.IsSuccess);
		result.Value.Should().BeEquivalentTo(expectedResult.Value);
	}
}
