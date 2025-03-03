namespace RailwayResult.FunctionalExtensions.Tests.Data;

public record BasicError(string Key, string Message) : Error(Key, Message);
