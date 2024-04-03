namespace RailwayResult.FunctionalExtensions.Benchmarks.Extensions;

public static class ListExtensions
{
	public static Task<T?> FirstOrDefaultAsync<T>(this List<T> list, Func<T, bool> predicate)
	{
		return Task.FromResult(list.FirstOrDefault(predicate));
	}
}
