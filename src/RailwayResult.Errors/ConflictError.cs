namespace RailwayResult.Errors;

public sealed record ConflictError(string Key, string Message) : Error(Key, Message);
