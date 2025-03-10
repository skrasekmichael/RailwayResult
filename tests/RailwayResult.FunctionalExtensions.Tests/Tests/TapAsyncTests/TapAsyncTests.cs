﻿using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.TapAsyncTests;

public sealed class TapAsyncTests : BaseTapTests
{
	[Theory]
	[ClassData(typeof(TheoryData_R_TapAsync))]
	public async Task R_TapAsync(Func<Result, Callback, Task<Result>> tapAsync, Result input, Result? expectedOutput, bool wasCallbackInvoked) => await VerifyAsync(tapAsync, input, expectedOutput, wasCallbackInvoked);

	[Theory]
	[ClassData(typeof(TheoryData_R1_TapAsync))]
	public async Task R1_TapAsync(Func<R1, Callback, Task<R1>> tapAsync, R1 input, R1? expectedOutput, bool wasCallbackInvoked) => await VerifyAsync(tapAsync, input, expectedOutput, wasCallbackInvoked);

	[Theory]
	[ClassData(typeof(TheoryData_R2_TapAsync))]
	public async Task R2_TapAsync(Func<R2, Callback, Task<R2>> tapAsync, R2 input, R2? expectedOutput, bool wasCallbackInvoked) => await VerifyAsync(tapAsync, input, expectedOutput, wasCallbackInvoked);
}
