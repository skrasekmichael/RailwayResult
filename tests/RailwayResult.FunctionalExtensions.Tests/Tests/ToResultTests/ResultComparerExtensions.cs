namespace RailwayResult.FunctionalExtensions.Tests.Tests.ToResultTests;

public static class ResultComparerExtensions
{
	public static void ShouldBeSameAs<T>(this Result resultA, Result<T> resultB)
	{
		if (resultA.IsSuccess)
		{
			resultB.IsSuccess.Should().BeTrue();
		}
		else
		{
			resultB.IsSuccess.Should().BeFalse();
			resultA.Error.Should().BeEquivalentTo(resultB.Error);
		}
	}
}
