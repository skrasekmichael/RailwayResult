namespace RailwayResult.FunctionalExtensions.Tests.EnsureTests;

public sealed class TheoryData_TaskOfObj_EnsureNotNull : TheoryData<Func<Task<O?>, Task<R1>>, O?, R1?>
{
	public TheoryData_TaskOfObj_EnsureNotNull()
	{
		//ensure should pass
		Add(
			result => result.EnsureNotNull(Errors.ErrorA),
			O.Empty,
			O.Empty
		);

		//ensure should fail
		Add(
			result => result.EnsureNotNull(Errors.ErrorA),
			null,
			Errors.ErrorA
		);
	}
}
