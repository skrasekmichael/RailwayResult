namespace RailwayResult.FunctionalExtensions.Tests.ThenTests;

public sealed class TheoryData_TaskOfR1_Then_TaskOfRC : TheoryData<Func<Task<R1>, Task<RC>>, R1, RC?>
{
	public TheoryData_TaskOfR1_Then_TaskOfRC()
	{
		Add(
			result => result.Then(o => o.Value),
			O.A,
			"A"
		);

		Add(
			result => result.Then(_ => "CC")!,
			O.A,
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.Then(o => o.Value),
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.Then(o => RC.Success(o.Value)),
			O.A,
			"A"
		);

		Add(
			result => result.Then(_ => RC.Success("CC")),
			O.A,
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.Then(o => RC.Success(o.Value)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.Then<O, string?>(_ => Errors.ErrorB),
			O.A,
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.Then<O, string?>(_ => Errors.ErrorB),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.Then(_ => BasicException.Throw<string?>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.Then(_ => BasicException.Throw<string?>()),
			O.A,
			null
		);

		//then should return input failure result
		Add(
			result => result.Then(_ => BasicException.Throw<RC>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.Then(_ => BasicException.Throw<RC>()),
			O.A,
			null
		);
	}
}
