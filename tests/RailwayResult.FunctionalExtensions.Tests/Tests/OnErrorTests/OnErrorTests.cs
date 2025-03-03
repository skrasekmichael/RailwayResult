using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Tests.TapTests;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.OnErrorTests;

public sealed class OnErrorTests : BaseTapTests
{
	[Theory]
	[ClassData(typeof(TheoryData_R_OnError))]
	public void R_OnError(Func<Result, Callback, Result> onError, Result input, Result? expectedOutput, bool wasCallbackInvoked) => Verify(onError, input, expectedOutput, wasCallbackInvoked);

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR_OnError))]
	public async Task TaskOfR_OnError(Func<Task<Result>, Callback, Task<Result>> onError, Result input, Result? expectedOutput, bool wasCallbackInvoked) => await VerifyAsync(onError, input, expectedOutput, wasCallbackInvoked);

	[Theory]
	[ClassData(typeof(TheoryData_R1_OnError))]
	public void R1_OnError(Func<R1, Callback, R1> tap, R1 input, R1? expectedOutput, bool wasCallbackInvoked) => Verify(tap, input, expectedOutput, wasCallbackInvoked);

	[Theory]
	[ClassData(typeof(TheoryData_TaskOfR1_OnError))]
	public async Task TaskOfR1_OnError(Func<Task<R1>, Callback, Task<R1>> tap, R1 input, R1? expectedOutput, bool wasCallbackInvoked) => await VerifyAsync(tap, input, expectedOutput, wasCallbackInvoked);
}
