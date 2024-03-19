namespace RailwayResult.FunctionalExtensions.Tests.EnsureTests;

public sealed class TheoryData_TaskOfObj_Ensure : TheoryData<Func<Task<O>, Task<R1>>, O, R1>
{
	public TheoryData_TaskOfObj_Ensure()
	{
		//ensure should pass
		Add(
			result => result.Ensure(Rules.IsNullOrWhiteSpaceRule, Errors.ErrorA),
			string.Empty,
			string.Empty
		);

		//ensure should fail
		Add(
			result => result.Ensure(s => !Rules.IsNullOrWhiteSpaceRule(s), Errors.ErrorA),
			string.Empty,
			Errors.ErrorA
		);

		//all rules should pass
		Add(
			result => result.Ensure(Rules.IsEmpty, Rules.IsNullOrWhiteSpace, Rules.CountIs(0)),
			string.Empty,
			string.Empty
		);

		//last rule should fail
		Add(
			result => result.Ensure(Rules.IsEmpty, Rules.IsNullOrWhiteSpace, Rules.CountIs(1)),
			string.Empty,
			Rules.CountIs(1).Error
		);
	}
}
