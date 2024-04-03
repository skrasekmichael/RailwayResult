using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.EnsureTests;

public sealed class TheoryData_Obj_Ensure : TheoryData<Func<O, R1>, O, R1?>
{
	public TheoryData_Obj_Ensure()
	{
		//ensure should pass
		Add(
			result => result.Ensure(Rules.IsNullOrWhiteSpaceRule, Errors.ErrorA),
			O.Empty,
			O.Empty
		);

		//ensure should fail
		Add(
			result => result.Ensure(s => !Rules.IsNullOrWhiteSpaceRule(s), Errors.ErrorA),
			O.Empty,
			Errors.ErrorA
		);

		//all rules should pass
		Add(
			result => result.Ensure(Rules.IsEmpty, Rules.IsNullOrWhiteSpace, Rules.CountIs(0)),
			O.Empty,
			O.Empty
		);

		//last rule should fail
		Add(
			result => result.Ensure(Rules.IsEmpty, Rules.IsNullOrWhiteSpace, Rules.CountIs(1)),
			O.Empty,
			Rules.CountIs(1).Error
		);

		//ensure should propagate exception
		Add(
			result => result.Ensure(Rules.RuleException, Errors.ErrorA),
			O.Empty,
			null
		);

		//ensure should propagate exception
		Add(
			result => result.Ensure(Rules.IsEmpty, Rules.ORuleWithErrorException),
			O.Empty,
			null
		);
	}
}
