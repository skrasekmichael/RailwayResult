namespace RailwayResult.Errors;

public sealed record AuthorizationError(string Key, string Message) : Error(Key, Message);
