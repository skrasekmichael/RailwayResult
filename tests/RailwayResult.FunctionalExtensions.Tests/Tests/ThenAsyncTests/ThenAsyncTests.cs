namespace RailwayResult.FunctionalExtensions.Tests.Tests.ThenAsyncTests;

public sealed class ThenAsyncTests : BaseTests
{
	[Theory]
	[ClassData(typeof(TheoryData_R1_ThenAsync_TaskOfR))]
	public async Task R1_ThenAsync_TaskOfR(Func<R1, Task<Result>> thenAsync, R1 input, Result? expectedOutput) => await VerifyAsync(thenAsync, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R1_ThenAsync_TaskOfRC))]
	public async Task R1_ThenAsync_TaskOfRC(Func<R1, Task<RC>> thenAsync, R1 input, RC? expectedOutput) => await VerifyAsync(thenAsync, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R2_ThenAsync_TaskOfR))]
	public async Task R2_ThenAsync_TaskOfR(Func<R2, Task<Result>> thenAsync, R2 input, Result? expectedOutput) => await VerifyAsync(thenAsync, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R2_ThenAsync_TaskOfRC))]
	public async Task R2_Thensync_TAskOfRC(Func<R2, Task<RC>> thenAsync, R2 input, RC? expectedOutput) => await VerifyAsync(thenAsync, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R3_ThenAsync_TaskOfR))]
	public async Task R3_ThenAsync_TaskOfR(Func<R3, Task<Result>> thenAsync, R3 input, Result? expectedOutput) => await VerifyAsync(thenAsync, input, expectedOutput);

	[Theory]
	[ClassData(typeof(TheoryData_R3_ThenAsync_TaskOfRC))]
	public async Task R3_ThenAsync_TaskOfRC(Func<R3, Task<RC>> thenAsync, R3 input, RC? expectedOutput) => await VerifyAsync(thenAsync, input, expectedOutput);
}
