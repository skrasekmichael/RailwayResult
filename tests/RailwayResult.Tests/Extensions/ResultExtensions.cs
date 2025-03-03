namespace RailwayResult.Tests.Extensions;

public static class ResultExtensions
{
	public static void ShouldBeEquivalentToResult(this Result self, Result expected)
	{
		if (self!.IsSuccess)
		{
			expected.IsSuccess.ShouldBeTrue();
		}
		else
		{
			expected.IsSuccess.ShouldBeFalse();
			self.Error.ShouldBeEquivalentTo(expected.Error);
		}
	}

	public static void ShouldBeEquivalentToResult<T>(this Result<T> self, Result<T> expected)
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
}
