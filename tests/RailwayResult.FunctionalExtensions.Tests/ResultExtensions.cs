namespace RailwayResult.FunctionalExtensions.Tests;

public static class ResultExtensions
{
	public static void ShouldBe(this Result self, Result expected)
	{
		if (self.IsSuccess)
		{
			expected.IsSuccess.Should().BeTrue();
		}
		else
		{
			expected.IsSuccess.Should().BeFalse();
			self.Error.Should().BeEquivalentTo(expected.Error);
		}
	}

	public static void ShouldBe<T>(this Result<T> self, Result<T> expected)
	{
		if (self.IsSuccess)
		{
			expected.IsSuccess.Should().BeTrue();
			self.Value.Should().BeEquivalentTo(expected.Value);
		}
		else
		{
			expected.IsSuccess.Should().BeFalse();
			self.Error.Should().BeEquivalentTo(expected.Error);
		}
	}

	public static Task<Result> ToResultTask(this Result result) => Task.FromResult(result);

	public static Task<Result<T>> ToResultTask<T>(this Result<T> result) => Task.FromResult(result);
}
