namespace RailwayResult.FunctionalExtensions.Tests.Tests.ThenTests;

public sealed class ThenTests : BaseTests
{
	[Theory]
	[ClassData(typeof(TheoryData_R1_Then_R))]
	public void R1_Then_R(Func<R1, Result> then, R1 input, Result? expectedOutput) => Verify(then, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR1_Then_TaskOfR))]
	public async Task TaskOfR1_Then_TaskOfR(Func<Task<R1>, Task<Result>> then, R1 input, Result? expectedOutput) => await VerifyAsync(then, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R1_Then_RC))]
	public void R1_Then_RC(Func<R1, RC> then, R1 input, RC? expectedOutput) => Verify(then, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR1_Then_TaskOfRC))]
	public async Task TaskOfR1_Then_TaskOfRC(Func<Task<R1>, Task<RC>> then, R1 input, RC? expectedOutput) => await VerifyAsync(then, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R2_Then_R))]
	public void R2_Then_R(Func<R2, Result> then, R2 input, Result? expectedOutput) => Verify(then, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR2_Then_TaskOfR))]
	public async Task TaskOfR2_Then_TaskOfR(Func<Task<R2>, Task<Result>> then, R2 input, Result? expectedOutput) => await VerifyAsync(then, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R2_Then_RC))]
	public void R2_Then_RC(Func<R2, RC> then, R2 input, RC? expectedOutput) => Verify(then, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR2_Then_TaskOfRC))]
	public async Task TaskOfR2_Then_TaskOfRC(Func<Task<R2>, Task<RC>> then, R2 input, RC? expectedOutput) => await VerifyAsync(then, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R3_Then_R))]
	public void R3_Then_R(Func<R3, Result> then, R3 input, Result? expectedOutput) => Verify(then, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR3_Then_TaskOfR))]
	public async Task TaskOfR3_Then_TaskOfR(Func<Task<R3>, Task<Result>> then, R3 input, Result? expectedOutput) => await VerifyAsync(then, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R3_Then_RC))]
	public void R3_Then_RC(Func<R3, RC> then, R3 input, RC? expectedOutput) => Verify(then, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR3_Then_TaskOfRC))]
	public async Task TaskOfR3_Then_TaskOfRC(Func<Task<R3>, Task<RC>> then, R3 input, RC? expectedOutput) => await VerifyAsync(then, input, expectedOutput);
}
