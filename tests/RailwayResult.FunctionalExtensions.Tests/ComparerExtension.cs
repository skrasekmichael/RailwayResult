namespace RailwayResult.FunctionalExtensions.Tests;

public static class ComparerExtension
{
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
}
