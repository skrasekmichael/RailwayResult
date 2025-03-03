namespace RailwayResult.Tests;

public sealed class Result_AccessingValueAndError_Tests
{
	[Fact]
	public void AccessingErrorOfSuccessResult_Should_ResultInException()
	{
		//arrange
		Result result = Result.Success;

		//act
		var accessor = () => result.Error;

		//assert
		accessor.ShouldThrow<AccessingErrorOfSuccessResultException>();
	}

	[Fact]
	public void AccessingErrorOfFailureResult_Should_NotResultInException()
	{
		//arrange
		var expectedError = new BasicError("Tests.Error", "Error");
		Result failedResult = expectedError;

		//act
		var error = failedResult.Error;

		//assert
		error.ShouldBe(expectedError);
	}

	[Fact]
	public void AccessingErrorOfGenericSuccessResult_Should_ResultInException()
	{
		//arrange
		Result<string> result = "Success";

		//act
		var accessor = () => result.Error;

		//assert
		accessor.ShouldThrow<AccessingErrorOfSuccessResultException>();
	}

	[Fact]
	public void AccessingErrorOfGenericFailureResult_Should_NotResultInException()
	{
		//arrange
		var expectedError = new BasicError("Tests.Error", "Error");
		Result<string> failedResult = expectedError;

		//act
		var error = failedResult.Error;

		//assert
		error.ShouldBe(expectedError);
	}

	[Fact]
	public void AccessingValueOfFailureGenericResult_Should_ResultInException()
	{
		//arrange
		Result<string> failedResult = new BasicError("Tests.Error", "Error");

		//act
		var accessor = () => failedResult.Value;

		//assert
		accessor.ShouldThrow<AccessingValueOfFailureResultException>();
	}

	[Fact]
	public void AccessingValueOfGenericSuccessResult_Should_NotResultInException()
	{
		//arrange
		Result<string> result = "Success";

		//act
		var value = result.Value;

		//assert
		value.ShouldBe("Success");
	}
}
