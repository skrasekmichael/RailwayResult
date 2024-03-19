using RailwayResult.FunctionalExtensions.Tests.EnsureTests;

namespace RailwayResult.FunctionalExtensions.Tests.EnsureNotNullTests;

public sealed class EnsureNotNullTests
{
	[Theory]
	[ClassData(typeof(TheoryData_Obj_EnsureNotNull))]
	public void Obj_EnsureNotNull(Func<O?, R1> ensureNotNull, O? input, R1 expectedOutput)
	{
		ensureNotNull.Invoke(input).ShouldBe(expectedOutput);
	}

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfObj_EnsureNotNull))]
	public async Task TaskOfObj_EnsureNotNull(Func<Task<O?>, Task<R1>> ensureNotNull, O? input, R1 expectedOutput)
	{
		var result = await ensureNotNull.Invoke(Task.FromResult(input));
		result.ShouldBe(expectedOutput);
	}

	[Theory]
	[ClassData(typeof(TheoryData_R1_EnsureNotNull))]
	public void R1_EnsureNotNull(Func<R1N, R1> ensureNotNull, R1N input, R1 expectedOutput)
	{
		ensureNotNull.Invoke(input).ShouldBe(expectedOutput);
	}

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR1_EnsureNotNull))]
	public async Task TaskOfR1_EnsureNotNull(Func<Task<R1N>, Task<R1>> ensureNotNull, R1N input, R1 expectedOutput)
	{
		var result = await ensureNotNull.Invoke(Task.FromResult(input));
		result.ShouldBe(expectedOutput);
	}

	[Theory]
	[ClassData(typeof(TheoryData_R2_EnsureNotNull))]
	public void R2_EnsureNotNull(Func<R2N, R2> ensureNotNull, R2N input, R2 expectedOutput)
	{
		ensureNotNull.Invoke(input).ShouldBe(expectedOutput);
	}

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR2_EnsureNotNull))]
	public async Task TaskOfR2_EnsureNotNull(Func<Task<R2N>, Task<R2>> ensureNotNull, R2N input, R2 expectedOutput)
	{
		var result = await ensureNotNull.Invoke(Task.FromResult(input));
		result.ShouldBe(expectedOutput);
	}
}
