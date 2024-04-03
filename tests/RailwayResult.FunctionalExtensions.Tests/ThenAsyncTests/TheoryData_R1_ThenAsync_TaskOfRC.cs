namespace RailwayResult.FunctionalExtensions.Tests.ThenAsyncTests;

public sealed class TheoryData_R1_ThenAsync_TaskOfRC : TheoryData<Func<R1, Task<RC>>, R1, RC?>
{
	public TheoryData_R1_ThenAsync_TaskOfRC()
	{
		// --- R1 ThenAsync TaskOfRC ---

		Add(
			result => result.ThenAsync(o => Task.FromResult(o.Value)),
			O.A,
			"A"
		);

		Add(
			result => result.ThenAsync(_ => Task.FromResult("CC"))!,
			O.A,
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync(o => Task.FromResult(o.Value)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.ThenAsync(o => RC.Success(o.Value).ToResultTask()),
			O.A,
			"A"
		);

		Add(
			result => result.ThenAsync(_ => RC.Success("CC").ToResultTask()),
			O.A,
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync(o => RC.Success(o.Value).ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ThenAsync(_ => Errors.ErrorB.ToResultTask<string?, BasicError>()),
			O.A,
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync(_ => Errors.ErrorB.ToResultTask<string?, BasicError>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync(_ => BasicException.Throw<Task<string?>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ThenAsync(_ => BasicException.Throw< Task<string?>>()),
			O.A,
			null
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync(_ => BasicException.Throw<Task<RC>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ThenAsync(_ => BasicException.Throw<Task<RC>>()),
			O.A,
			null
		);

		// --- TaskOfR1 ThenAsync TaskOfRC ---

		Add(
			result => result.ToResultTask().ThenAsync(o => Task.FromResult(o.Value)),
			O.A,
			"A"
		);

		Add(
			result => result.ToResultTask().ThenAsync(_ => Task.FromResult("CC"))!,
			O.A,
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync(o => Task.FromResult(o.Value)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.ToResultTask().ThenAsync(o => RC.Success(o.Value).ToResultTask()),
			O.A,
			"A"
		);

		Add(
			result => result.ToResultTask().ThenAsync(_ => RC.Success("CC").ToResultTask()),
			O.A,
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync(o => RC.Success(o.Value).ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ToResultTask().ThenAsync(_ => Errors.ErrorB.ToResultTask<string?, BasicError>()),
			O.A,
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync(_ => Errors.ErrorB.ToResultTask<string?, BasicError>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync(_ => BasicException.Throw<Task<string?>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ToResultTask().ThenAsync(_ => BasicException.Throw<Task<string?>>()),
			O.A,
			null
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync(_ => BasicException.Throw<Task<RC>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ToResultTask().ThenAsync(_ => BasicException.Throw<Task<RC>>()),
			O.A,
			null
		);
	}
}
