namespace RailwayResult.FunctionalExtensions.Tests.AndTests;

public sealed class TheoryData_R1_And : TheoryData<Func<R1, R2>, R1, R2?>
{
	public TheoryData_R1_And()
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

		//and should return input failure result
		Add(
			result => result.And<O, O>(_ => BasicException.Throw<O>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should propagate exception
		Add(
			result => result.And<O, O>(_ => BasicException.Throw<O>()),
			O.A,
			null
		);

		//and should return input failure result
		Add(
			result => result.And(_ => BasicException.Throw<R1>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should propagate exception
		Add(
			result => result.And(_ => BasicException.Throw<R1>()),
			O.A,
			null
		);
	}
}
