namespace RailwayResult.FunctionalExtensions.Tests.AndTests;

public sealed class TheoryData_TaskOfR1_And : TheoryData<Func<Task<R1>, Task<R2>>, R1, R2>
{
	public TheoryData_TaskOfR1_And()
	{
		Add(
			result => result.And(() => O.B),
			O.A,
			(O.A, O.B)
		);

		//and should return input failure result
		Add(
			result => result.And(() => O.B),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//nested result should be unwrapped
		Add(
			result => result.And(() => R1.Success(O.B)),
			O.A,
			(O.A, O.B)
		);

		//and should return input failure result
		Add(
			result => result.And(() => R1.Success(O.B)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should return error from nested result
		Add(
			result => result.And<O, O>(() => Errors.ErrorB),
			O.A,
			Errors.ErrorB
		);

		//nested result should be unwrapped
		Add(
			result => result.And(_ => R1.Success(O.B)),
			O.A,
			(O.A, O.B)
		);

		//and should return input failure result
		Add(
			result => result.And(_ => R1.Success(O.B)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should return error from nested result
		Add(
			result => result.And<O, O>(_ => Errors.ErrorB),
			O.A,
			Errors.ErrorB
		);
	}
}
