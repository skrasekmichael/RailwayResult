using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.ThenAsyncTests;

public sealed class TheoryData_R2_ThenAsync_TaskOfRC : TheoryData<Func<R2, Task<RC>>, R2, RC?>
{
	public TheoryData_R2_ThenAsync_TaskOfRC()
	{
		AddData_R2_ThenAsync_TaskOfRC();
		AddData_TaskOfR2_ThenAsync_TaskOfRC();
	}

	private void AddData_R2_ThenAsync_TaskOfRC()
	{
		Add(
			result => result.ThenAsync((a, b) => Task.FromResult(a.Value + b.Value))!,
			(O.A, O.B),
			"AB"
		);

		Add(
			result => result.ThenAsync((_, _) => Task.FromResult("CC"))!,
			(O.A, O.B),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _) => Task.FromResult("CC"))!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.ThenAsync((a, b) => RC.Success(a.Value + b.Value).ToResultTask())!,
			(O.A, O.B),
			"AB"
		);

		Add(
			result => result.ThenAsync((_, _) => RC.Success("CC").ToResultTask())!,
			(O.A, O.B),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _) => RC.Success("CC").ToResultTask())!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _) => Errors.ErrorC.ToResultTask<string?, BasicError>())!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ThenAsync((_, _) => Errors.ErrorC.ToResultTask<string?, BasicError>())!,
			(O.A, O.B),
			Errors.ErrorC
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _) => BasicException.Throw<Task<string?>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ThenAsync((_, _) => BasicException.Throw<Task<string?>>()),
			(O.A, O.B),
			null
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _) => BasicException.Throw<Task<RC>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ThenAsync((_, _) => BasicException.Throw<Task<RC>>()),
			(O.A, O.B),
			null
		);
	}

	private void AddData_TaskOfR2_ThenAsync_TaskOfRC()
	{
		Add(
			result => result.ToResultTask().ThenAsync((a, b) => Task.FromResult(a.Value + b.Value))!,
			(O.A, O.B),
			"AB"
		);

		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Task.FromResult("CC"))!,
			(O.A, O.B),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Task.FromResult("CC"))!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.ToResultTask().ThenAsync((a, b) => RC.Success(a.Value + b.Value).ToResultTask())!,
			(O.A, O.B),
			"AB"
		);

		Add(
			result => result.ToResultTask().ThenAsync((_, _) => RC.Success("CC").ToResultTask())!,
			(O.A, O.B),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => RC.Success("CC").ToResultTask())!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Errors.ErrorC.ToResultTask<string?, BasicError>())!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Errors.ErrorC.ToResultTask<string?, BasicError>())!,
			(O.A, O.B),
			Errors.ErrorC
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => BasicException.Throw<Task<string?>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => BasicException.Throw<Task<string?>>()),
			(O.A, O.B),
			null
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => BasicException.Throw<Task<RC>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => BasicException.Throw<Task<RC>>()),
			(O.A, O.B),
			null
		);
	}
}
