using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.ThenAsyncTests;

public sealed class TheoryData_R2_ThenAsync_TaskOfR : TheoryData<Func<R2, Task<Result>>, R2, Result?>
{
	public TheoryData_R2_ThenAsync_TaskOfR()
	{
		// --- R2 ThenAsync TaskOfRC ---

		Add(
			result => result.ThenAsync((_, _) => Result.Success.ToResultTask()),
			(O.A, O.B),
			Result.Success
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _) => Result.Success.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _) => Errors.ErrorB.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ThenAsync((_, _) => Errors.ErrorB.ToResultTask()),
			(O.A, O.B),
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _) => BasicException.Throw<Task<Result>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ThenAsync((_, _) => BasicException.Throw<Task<Result>>()),
			(O.A, O.B),
			null
		);

		// --- TaskOfR2 ThenAsync TaskOfRC ---

		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Result.Success.ToResultTask()),
			(O.A, O.B),
			Result.Success
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Result.Success.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Errors.ErrorB.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Errors.ErrorB.ToResultTask()),
			(O.A, O.B),
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => BasicException.Throw<Task<Result>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => BasicException.Throw<Task<Result>>()),
			(O.A, O.B),
			null
		);
	}
}
