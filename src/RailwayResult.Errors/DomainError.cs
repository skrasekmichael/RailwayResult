namespace RailwayResult.Errors;

public sealed record DomainError(string Key, string Message) : Error(Key, Message);
