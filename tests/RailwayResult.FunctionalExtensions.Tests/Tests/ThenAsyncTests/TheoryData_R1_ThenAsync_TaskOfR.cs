using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.ThenAsyncTests;

public sealed class TheoryData_R1_ThenAsync_TaskOfR : TheoryData<Func<R1, Task<Result>>, R1, Result?>
{
	public TheoryData_R1_ThenAsync_TaskOfR()
	{
		AddData_R1_ThemAsync_TaskOfR();
		AddData_Task_OfR1_ThenAsync_TaskOfR();
	}

	private void AddData_R1_ThemAsync_TaskOfR()
	{
		Add(
			result => result.ThenAsync(_ => Result.Success.ToResultTask()),
			O.A,
			Result.Success
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync(_ => Result.Success.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync(_ => Errors.ErrorB.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ThenAsync(_ => Errors.ErrorB.ToResultTask()),
			O.A,
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync(_ => BasicException.Throw<Task<Result>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ThenAsync(_ => BasicException.Throw<Task<Result>>()),
			O.A,
			null
		);
	}

	private void AddData_Task_OfR1_ThenAsync_TaskOfR()
	{
		Add(
			result => result.ToResultTask().ThenAsync(_ => Result.Success.ToResultTask()),
			O.A,
			Result.Success
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync(_ => Result.Success.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync(_ => Errors.ErrorB.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ToResultTask().ThenAsync(_ => Errors.ErrorB.ToResultTask()),
			O.A,
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync(_ => BasicException.Throw<Task<Result>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ToResultTask().ThenAsync(_ => BasicException.Throw<Task<Result>>()),
			O.A,
			null
		);
	}
}
