namespace RailwayResult.FunctionalExtensions.Tests.Data;

public sealed record BasicError(string Key, string Message) : Error(Key, Message);
