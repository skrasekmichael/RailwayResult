﻿namespace RailwayResults.Tests.Mocks;

public sealed record GenericError(string Key, string Message) : Error(Key, Message)
{
	public static readonly GenericError ErrorA = new("Key", "Error A");
}
