namespace RailwayResult.FunctionalExtensions.Tests.Tests.ToResultTests;

public static class ResultComparerExtensions
{
	public static void ShouldBeSameAs<T>(this Result resultA, Result<T> resultB)
	{
		if (resultA.IsSuccess)
		{
			resultB.IsSuccess.ShouldBeTrue();
		}
		else
		{
			resultB.IsSuccess.ShouldBeFalse();
			resultA.Error.ShouldBeEquivalentTo(resultB.Error);
		}
	}
}
