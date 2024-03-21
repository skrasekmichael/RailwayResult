namespace RailwayResult.FunctionalExtensions.Tests.ToResultTests;

public sealed class ToResultTests
{
	public static IEnumerable<object[]> Data
	{
		get
		{
			yield return new object[] { R1.Success(O.A) };
			yield return new object[] { Errors.ErrorA.ToResult<O, BasicError>() };
			yield return new object[] { R2.Success((O.A, O.B)) };
			yield return new object[] { Errors.ErrorB.ToResult<(O, O), BasicError>() };
			yield return new object[] { R3.Success((O.A, O.B, O.C)) };
			yield return new object[] { Errors.ErrorC.ToResult<(O, O, O), BasicError>() };
		}
	}

	[Theory]
	[MemberData(nameof(Data))]
	public void GenericResult_ToResult_Should_ReturnResultOnCorrectRailwayWithCorrectError<T>(Result<T> input)
	{
		//act
		var result = input.ToResult();

		//assert
		result.ShouldBeSameAs(input);
	}

	[Theory]
	[MemberData(nameof(Data))]
	public async Task TaskOfGenericResult_ToResultAsync_Should_ReturnResultOnCorrectRailwayWithCorrectError<T>(Result<T> input)
	{
		//arrange
		var inputTask = input.ToResultTask();

		//act
		var result = await inputTask.ToResultAsync();

		//assert
		result.ShouldBeSameAs(input);
	}
}
