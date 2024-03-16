namespace RailwayResult;

public abstract record Error<TSelf> : ErrorBase where TSelf : Error<TSelf>, new()
{
	public static TSelf New(string message, string key = "")
	{
		return new TSelf()
		{
			Key = key,
			Message = message
		};
	}
}
