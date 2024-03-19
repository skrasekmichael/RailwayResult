namespace RailwayResult.FunctionalExtensions.Tests.EnsureTests;

public sealed class EnsureTests
{
	[Theory]
	[ClassData(typeof(TheoryData_Obj_Ensure))]
	public void Obj_Ensure(Func<O, R1> ensure, O input, R1 expectedOutput)
	{
		ensure.Invoke(input).ShouldBe(expectedOutput);
	}

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfObj_Ensure))]
	public async Task TaskOfObj_Ensure(Func<Task<O>, Task<R1>> ensure, O input, R1 expectedOutput)
	{
		var result = await ensure.Invoke(Task.FromResult(input));
		result.ShouldBe(expectedOutput);
	}

	[Theory]
	[ClassData(typeof(TheoryData_R1_Ensure))]
	public void R1_Ensure(Func<R1, R1> ensure, R1 input, R1 expectedOutput)
	{
		ensure.Invoke(input).ShouldBe(expectedOutput);
	}

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR1_Ensure))]
	public async Task TaskOfR1_Ensure(Func<Task<R1>, Task<R1>> ensure, R1 input, R1 expectedOutput)
	{
		var result = await ensure.Invoke(Task.FromResult(input));
		result.ShouldBe(expectedOutput);
	}

	[Theory]
	[ClassData(typeof(TheoryData_R2_Ensure))]
	public void R2_Ensure(Func<R2, R2> ensure, R2 input, R2 expectedOutput)
	{
		ensure.Invoke(input).ShouldBe(expectedOutput);
	}

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR2_Ensure))]
	public async Task TaskOfR2_Ensure(Func<Task<R2>, Task<R2>> ensure, R2 input, R2 expectedOutput)
	{
		var result = await ensure.Invoke(Task.FromResult(input));
		result.ShouldBe(expectedOutput);
	}
}
