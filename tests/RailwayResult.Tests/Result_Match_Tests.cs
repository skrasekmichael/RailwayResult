namespace RailwayResult.Tests;

public sealed class Result_Match_Tests
{
	[Fact]
	public void Match_OnFailureResult_Should_ReturnOnFailureMapping()
	{
		//arrange
		Result result = GenericError.ErrorA;

		//act
		var mappedValue = result.Match(() => 0, _ => 1);

		//assert
		mappedValue.Should().Be(1);
	}

	[Fact]
	public void Match_OnSuccessResult_Should_ReturnOnSuccessMapping()
	{
		//arrange
		Result result = Result.Success;

		//act
		var mappedValue = result.Match(() => 0, _ => 1);

		//assert
		mappedValue.Should().Be(0);
	}

	[Fact]
	public void Match_OnGenericFailureResult_Should_ReturnOnFailureMapping()
	{
		//arrange
		Result<string> result = GenericError.ErrorA;

		//act
		var mappedValue = result.Match(_ => 0, _ => 1);

		//assert
		mappedValue.Should().Be(1);
	}

	[Fact]
	public void Match_OnGenericSuccessResult_Should_ReturnOnSuccessMapping()
	{
		//arrange
		Result<string> result = "Error";

		//act
		var mappedValue = result.Match(_ => 0, _ => 1);

		//assert
		mappedValue.Should().Be(0);
	}
}
