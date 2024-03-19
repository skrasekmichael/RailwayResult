namespace RailwayResult.FunctionalExtensions.Tests;

public sealed record BasicError(string Key, string Message) : Error(Key, Message);
