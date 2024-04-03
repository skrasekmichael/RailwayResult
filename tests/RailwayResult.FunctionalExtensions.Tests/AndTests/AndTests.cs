namespace RailwayResult.FunctionalExtensions.Tests.AndTests;

public sealed class AndTests : BaseTests
{
	[Theory]
	[ClassData(typeof(TheoryData_R1_And))]
	public void R1_And(Func<R1, R2> and, R1 input, R2? expectedOutput) => Verify(and, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR1_And))]
	public async Task TaskOfR1_And(Func<Task<R1>, Task<R2>> and, R1 input, R2? expectedOutput) => await VerifyAsync(and, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R2_And))]
	public void R2_And(Func<R2, R3> and, R2 input, R3? expectedOutput) => Verify(and, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR2_And))]
	public async Task TaskOfR2_And(Func<Task<R2>, Task<R3>> and, R2 input, R3 expectedOutput) => await VerifyAsync(and, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R1_AndAsync))]
	public async Task R1_AndAsync(Func<R1, Task<R2>> andAsync, R1 input, R2 expectedOutput) => await VerifyAsync(andAsync, input, expectedOutput);
}
