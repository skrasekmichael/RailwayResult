namespace RailwayResult.FunctionalExtensions.Tests.Extensions;

public static class ResultExtensions
{
	public static void ShouldBe(this Result self, Result expected)
	{
		if (self.IsSuccess)
		{
			expected.IsSuccess.ShouldBeTrue();
		}
		else
		{
			expected.IsSuccess.ShouldBeFalse();
			self.Error.ShouldBeEquivalentTo(expected.Error);
		}
	}

	public static void ShouldBe<T>(this Result<T> self, Result<T> expected)
	{
		if (self.IsSuccess)
		{
			expected.IsSuccess.ShouldBeTrue();
			self.Value.ShouldBeEquivalentTo(expected.Value);
		}
		else
		{
			expected.IsSuccess.ShouldBeFalse();
			self.Error.ShouldBeEquivalentTo(expected.Error);
		}
	}

	public static Task<Result> ToResultTask(this Result result) => Task.FromResult(result);

	public static Task<Result<T>> ToResultTask<T>(this Result<T> result) => Task.FromResult(result);
}
