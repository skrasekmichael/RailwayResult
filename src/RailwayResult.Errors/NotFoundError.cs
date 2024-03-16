namespace RailwayResult.Errors;

public sealed record NotFoundError(string Key, string Message) : Error(Key, Message);
