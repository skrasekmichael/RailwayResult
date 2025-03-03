using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.ThenAsyncTests;

public sealed class TheoryData_R3_ThenAsync_TaskOfRC : TheoryData<Func<R3, Task<RC>>, R3, RC?>
{
	public TheoryData_R3_ThenAsync_TaskOfRC()
	{
		AddData_R3_ThenAsync_TaskOfRC();
		AddData_TaskOfR3_ThenAsync_TaskOfRC();
	}

	private void AddData_R3_ThenAsync_TaskOfRC()
	{
		Add(
			result => result.ThenAsync((a, b, c) => Task.FromResult(a.Value + b.Value + c.Value))!,
			(O.A, O.B, O.C),
			"ABC"
		);

		Add(
			result => result.ThenAsync((_, _, _) => Task.FromResult("CC"))!,
			(O.A, O.B, O.C),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _, _) => Task.FromResult("CC"))!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.ThenAsync((a, b, c) => RC.Success(a.Value + b.Value + c.Value).ToResultTask()),
			(O.A, O.B, O.C),
			"ABC"
		);

		Add(
			result => result.ThenAsync((_, _, _) => RC.Success("CC").ToResultTask()),
			(O.A, O.B, O.C),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _, _) => RC.Success("CC").ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ThenAsync((_, _, _) => Errors.ErrorB.ToResultTask<string?, BasicError>()),
			(O.A, O.B, O.C),
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _, _) => Errors.ErrorB.ToResultTask<string?, BasicError>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _, _) => BasicException.Throw<Task<string?>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ThenAsync((_, _, _) => BasicException.Throw<Task<string?>>()),
			(O.A, O.B, O.C),
			null
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _, _) => BasicException.Throw<Task<RC>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ThenAsync((_, _, _) => BasicException.Throw<Task<RC>>()),
			(O.A, O.B, O.C),
			null
		);
	}

	private void AddData_TaskOfR3_ThenAsync_TaskOfRC()
	{
		Add(
			result => result.ToResultTask().ThenAsync((a, b, c) => Task.FromResult(a.Value + b.Value + c.Value))!,
			(O.A, O.B, O.C),
			"ABC"
		);

		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => Task.FromResult("CC"))!,
			(O.A, O.B, O.C),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => Task.FromResult("CC"))!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.ToResultTask().ThenAsync((a, b, c) => RC.Success(a.Value + b.Value + c.Value).ToResultTask()),
			(O.A, O.B, O.C),
			"ABC"
		);

		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => RC.Success("CC").ToResultTask()),
			(O.A, O.B, O.C),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => RC.Success("CC").ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => Errors.ErrorB.ToResultTask<string?, BasicError>()),
			(O.A, O.B, O.C),
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => Errors.ErrorB.ToResultTask<string?, BasicError>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => BasicException.Throw<Task<string?>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => BasicException.Throw<Task<string?>>()),
			(O.A, O.B, O.C),
			null
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => BasicException.Throw<Task<RC>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => BasicException.Throw<Task<RC>>()),
			(O.A, O.B, O.C),
			null
		);
	}
}
