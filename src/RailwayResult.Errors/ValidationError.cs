namespace RailwayResult.Errors;

public sealed record ValidationError(string Key, string Message) : Error(Key, Message);
