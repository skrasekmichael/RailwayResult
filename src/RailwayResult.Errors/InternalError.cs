namespace RailwayResult.Errors;

public sealed record InternalError(string Key, string Message) : Error(Key, Message);
