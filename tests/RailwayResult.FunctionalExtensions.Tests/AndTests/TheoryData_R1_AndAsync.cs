namespace RailwayResult.FunctionalExtensions.Tests.AndTests;

public sealed class TheoryData_R1_AndAsync : TheoryData<Func<R1, Task<R2>>, R1, R2>
{
	public TheoryData_R1_AndAsync()
	{
		// --- R1 ---

		Add(
			result => result.AndAsync(_ => Task.FromResult(O.B)),
			O.A,
			(O.A, O.B)
		);

		//and should return input failure result
		Add(
			result => result.AndAsync(_ => Task.FromResult(O.B)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		// --- TaskOfR1 ---

		Add(
			result => result.ToResultTask().AndAsync(_ => Task.FromResult(O.B)),
			O.A,
			(O.A, O.B)
		);

		//and should return input failure result
		Add(
			result => result.ToResultTask().AndAsync(_ => Task.FromResult(O.B)),
			Errors.ErrorA,
			Errors.ErrorA
		);
	}
}
