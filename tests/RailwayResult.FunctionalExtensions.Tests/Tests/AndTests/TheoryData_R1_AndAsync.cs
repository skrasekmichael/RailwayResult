using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.AndTests;

public sealed class TheoryData_R1_AndAsync : TheoryData<Func<R1, Task<R2>>, R1, R2?>
{
	public TheoryData_R1_AndAsync()
	{
		// --- R1 ---

		Add(
			result => result.AndAsync(_ => Task.FromResult(O.B)),
			O.A,
			(O.A, O.B)
		);

		//and should return input failure result
		Add(
			result => result.AndAsync(_ => Task.FromResult(O.B)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.AndAsync(_ => Task.FromResult<R1>(O.B)),
			O.A,
			(O.A, O.B)
		);

		//and should return input failure result
		Add(
			result => result.AndAsync(_ => Task.FromResult<R1>(O.B)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should return nested result error
		Add(
			result => result.AndAsync(_ => Task.FromResult<R1>(Errors.ErrorD)),
			O.A,
			Errors.ErrorD
		);

		//and should return input failure result
		Add(
			result => result.AndAsync(_ => Task.FromResult<R1>(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should return input failure result
		Add(
			result => result.AndAsync(_ => BasicException.Throw<Task<O>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should propagate exception
		Add(
			result => result.AndAsync(_ => BasicException.Throw<Task<O>>()),
			O.A,
			null
		);

		//and should return input failure result
		Add(
			result => result.AndAsync(_ => BasicException.Throw<Task<R1>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should propagate exception
		Add(
			result => result.AndAsync(_ => BasicException.Throw<Task<R1>>()),
			O.A,
			null
		);

		// --- TaskOfR1 ---

		Add(
			result => result.ToResultTask().AndAsync(_ => Task.FromResult(O.B)),
			O.A,
			(O.A, O.B)
		);

		//and should return input failure result
		Add(
			result => result.ToResultTask().AndAsync(_ => Task.FromResult(O.B)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.ToResultTask().AndAsync(_ => Task.FromResult<R1>(O.B)),
			O.A,
			(O.A, O.B)
		);

		//and should return input failure result
		Add(
			result => result.ToResultTask().AndAsync(_ => Task.FromResult<R1>(O.B)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should return nested result error
		Add(
			result => result.ToResultTask().AndAsync(_ => Task.FromResult<R1>(Errors.ErrorD)),
			O.A,
			Errors.ErrorD
		);

		//and should return input failure result
		Add(
			result => result.ToResultTask().AndAsync(_ => Task.FromResult<R1>(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should return input failure result
		Add(
			result => result.ToResultTask().AndAsync(_ => BasicException.Throw<Task<O>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should propagate exception
		Add(
			result => result.ToResultTask().AndAsync(_ => BasicException.Throw<Task<O>>()),
			O.A,
			null
		);

		//and should return input failure result
		Add(
			result => result.ToResultTask().AndAsync(_ => BasicException.Throw<Task<R1>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should propagate exception
		Add(
			result => result.ToResultTask().AndAsync(_ => BasicException.Throw<Task<R1>>()),
			O.A,
			null
		);
	}
}
