namespace RailwayResult.FunctionExtensions;

public interface IRuleWithError<T>
{
	public Result<T> Apply(T val);
}
