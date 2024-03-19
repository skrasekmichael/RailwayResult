namespace RailwayResult.FunctionalExtensions.Tests.EnsureTests;

public sealed class TheoryData_TaskOfR1_EnsureNotNull : TheoryData<Func<Task<R1N>, Task<R1>>, R1N, R1>
{
	public TheoryData_TaskOfR1_EnsureNotNull()
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
	}
}
