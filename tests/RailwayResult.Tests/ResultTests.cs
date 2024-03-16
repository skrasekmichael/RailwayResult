namespace RailwayResult.Tests;

public sealed class ResultTests
{
	[Fact]
	public void AccessingValueOfFailureResult_Should_ResultInException()
	{
		//arrange
		Result<string> failedResult = new GenericError("Tests.Error", "Error");

		//act
		var accessor = () => failedResult.Value;

		//assert
		accessor.Should().ThrowExactly<AccessingValueOfFailureResultException>();
	}

	[Fact]
	public void AccessingErrorOfSuccessResult_Should_ResultInException()
	{
		//arrange
		Result result = Result.Success;

		//act
		var accessor = () => result.Error;

		//assert
		accessor.Should().ThrowExactly<AccessingErrorOfSuccessResultException>();
	}

	[Fact]
	public void AccessingErrorOfGenericSuccessResult_Should_ResultInException()
	{
		//arrange
		Result<string> result = "Success";

		//act
		var accessor = () => result.Error;

		//assert
		accessor.Should().ThrowExactly<AccessingErrorOfSuccessResultException>();
	}
}
