using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.EnsureNotNullTests;

public sealed class TheoryData_Obj_EnsureNotNull : TheoryData<Func<O?, R1>, O?, R1?>
{
	public TheoryData_Obj_EnsureNotNull()
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
