namespace RailwayResult.Errors;

public sealed record AuthenticationError(string Key, string Message) : Error(Key, Message);
