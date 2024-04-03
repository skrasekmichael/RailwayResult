namespace RailwayResult.FunctionalExtensions.Tests.EnsureTests;

public sealed class TheoryData_R1_EnsureNotNull : TheoryData<Func<R1N, R1>, R1N, R1?>
{
	public TheoryData_R1_EnsureNotNull()
	{
		//ensure should pass
		Add(
			result => result.EnsureNotNull(Errors.ErrorA),
			O.Empty,
			O.Empty
		);

		//ensure should fail
		Add(
			result => result.EnsureNotNull(Errors.ErrorA),
			R1N.Success(null),
			Errors.ErrorA
		);

		//ensure should return input failure result
		Add(
			result => result.EnsureNotNull(Errors.ErrorA),
			Errors.ErrorD,
			Errors.ErrorD
		);

		//ensure with selector should pass
		Add(
			result => result.EnsureNotNull(o => o!.Value, Errors.ErrorA)!,
			O.Empty,
			O.Empty
		);

		//ensure with selector should fail
		Add(
			result => result.EnsureNotNull(o => o!.Value, Errors.ErrorA)!,
			O.Null,
			Errors.ErrorA
		);

		//ensure with selector should return input failure result
		Add(
			result => result.EnsureNotNull(o => o!.Value, Errors.ErrorA)!,
			Errors.ErrorD,
			Errors.ErrorD
		);

		//ensure should propagate exception
		Add(
			result => result.EnsureNotNull(_ => BasicException.Throw<string>(), Errors.ErrorA)!,
			O.Empty,
			null
		);

		//ensure should return input fail result
		Add(
			result => result.EnsureNotNull(_ => BasicException.Throw<string>(), Errors.ErrorA)!,
			Errors.ErrorD,
			Errors.ErrorD
		);
	}
}
