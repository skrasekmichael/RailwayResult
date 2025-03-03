using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.OnErrorAsyncTests;

public sealed class OnErrorAsyncTests : BaseTapTests
{
	[Theory]
	[ClassData(typeof(TheoryData_R_OnErrorAsync))]
	public async Task R_OnErrorAsync(Func<Result, Callback, Task<Result>> onError, Result input, Result? expectedOutput, bool wasCallbackInvoked) => await VerifyAsync(onError, input, expectedOutput, wasCallbackInvoked);

	[Theory]
	[ClassData(typeof(TheoryData_R1_OnErrorAsync))]
	public async Task TaskOfR1_OnErrorAsync(Func<R1, Callback, Task<R1>> tap, R1 input, R1? expectedOutput, bool wasCallbackInvoked) => await VerifyAsync(tap, input, expectedOutput, wasCallbackInvoked);
}
