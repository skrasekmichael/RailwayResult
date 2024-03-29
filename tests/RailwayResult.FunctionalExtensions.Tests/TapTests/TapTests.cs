﻿namespace RailwayResult.FunctionalExtensions.Tests.TapTests;

public sealed class TapTests
{
	private Callback Callback { get; } = new();

	[Theory]
	[ClassData(typeof(TheoryData_R_Tap))]
	public void R_Tap(Func<Result, Callback, Result> tap, Result input, Result expectedOutput, bool wasCallbackInvoked)
	{
		tap.Invoke(input, Callback).ShouldBe(expectedOutput);
		Callback.WasCalled.Should().Be(wasCallbackInvoked);
	}

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR_Tap))]
	public async Task TaskOfR_Tap(Func<Task<Result>, Callback, Task<Result>> tap, Result input, Result expectedOutput, bool wasCallbackInvoked)
	{
		var result = await tap.Invoke(input.ToResultTask(), Callback);
		result.ShouldBe(expectedOutput);
		Callback.WasCalled.Should().Be(wasCallbackInvoked);
	}

	[Theory]
	[ClassData(typeof(TheoryData_R1_Tap))]
	public void R1_Tap(Func<R1, Callback, R1> tap, R1 input, R1 expectedOutput, bool wasCallbackInvoked)
	{
		tap.Invoke(input, Callback).ShouldBe(expectedOutput);
		Callback.WasCalled.Should().Be(wasCallbackInvoked);
	}

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR1_Tap))]
	public async Task TaskOfR1_Tap(Func<Task<R1>, Callback, Task<R1>> tap, R1 input, R1 expectedOutput, bool wasCallbackInvoked)
	{
		var result = await tap.Invoke(input.ToResultTask(), Callback);
		result.ShouldBe(expectedOutput);
		Callback.WasCalled.Should().Be(wasCallbackInvoked);
	}

	[Theory]
	[ClassData(typeof(TheoryData_R2_Tap))]
	public void R2_Tap(Func<R2, Callback, R2> tap, R2 input, R2 expectedOutput, bool wasCallbackInvoked)
	{
		tap.Invoke(input, Callback).ShouldBe(expectedOutput);
		Callback.WasCalled.Should().Be(wasCallbackInvoked);
	}

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR2_Tap))]
	public async Task TaskOfR2_Tap(Func<Task<R2>, Callback, Task<R2>> tap, R2 input, R2 expectedOutput, bool wasCallbackInvoked)
	{
		var result = await tap.Invoke(input.ToResultTask(), Callback);
		result.ShouldBe(expectedOutput);
		Callback.WasCalled.Should().Be(wasCallbackInvoked);
	}
}
