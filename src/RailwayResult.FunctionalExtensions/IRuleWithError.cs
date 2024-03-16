namespace RailwayResult.FunctionalExtensions;

public interface IRuleWithError<T>
{
	public Result<T> Apply(T val);
}
