namespace RailwayResult.FunctionalExtensions.Benchmarks.Data;

public sealed record GenericError(string Message) : Error("", Message);
