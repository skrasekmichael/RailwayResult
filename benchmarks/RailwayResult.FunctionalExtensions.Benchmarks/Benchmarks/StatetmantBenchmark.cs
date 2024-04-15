using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

using RailwayResult.FunctionalExtensions.Benchmarks.Data;
using RailwayResult.FunctionalExtensions.Benchmarks.Seeds;

namespace RailwayResult.FunctionalExtensions.Benchmarks.Benchmarks;

[SimpleJob(RuntimeMoniker.Net80)]
public class StatementBenchmark
{
	public Fraction Fraction { get; set; } = null!;

	[GlobalSetup]
	public void Setup()
	{
		Fraction = FractionSeeds.JediOrder;
	}

	[Benchmark]
	public int FailEarly_RP()
	{
		var result = Fraction.UpdateRank_RP(Guid.Empty, Guid.Empty, Guid.Empty);
		return result.IsSuccess ? 1 : 0;
	}

	[Benchmark]
	public int FailEarly_ROP()
	{
		var result = Fraction.UpdateRank_ROP(Guid.Empty, Guid.Empty, Guid.Empty);
		return result.IsSuccess ? 1 : 0;
	}

	[Benchmark]
	public int FailEarly_Exception()
	{
		try
		{
			Fraction.UpdateRank_Exception(Guid.Empty, Guid.Empty, Guid.Empty);
			return 1;
		}
		catch
		{
			return 0;
		}
	}

	[Benchmark]
	public int FailLate_RP()
	{
		var result = Fraction.UpdateRank_RP(MemberSeeds.JediWindu.Id, MemberSeeds.JediKenobi.Id, RankSeeds.JediGrandMaster.Id);
		return result.IsSuccess ? 1 : 0;
	}

	[Benchmark]
	public int FailLate_ROP()
	{
		var result = Fraction.UpdateRank_ROP(MemberSeeds.JediWindu.Id, MemberSeeds.JediKenobi.Id, RankSeeds.JediGrandMaster.Id);
		return result.IsSuccess ? 1 : 0;
	}

	[Benchmark]
	public int FailLate_Exception()
	{
		try
		{
			Fraction.UpdateRank_Exception(MemberSeeds.JediWindu.Id, MemberSeeds.JediKenobi.Id, RankSeeds.JediGrandMaster.Id);
			return 1;
		}
		catch
		{
			return 0;
		}
	}

	[Benchmark]
	public async Task<int> FailEarlyAsync_RP()
	{
		var result = await Fraction.UpdateRankAsync_RP(Guid.Empty, Guid.Empty, Guid.Empty);
		return result.IsSuccess ? 1 : 0;
	}

	[Benchmark]
	public async Task<int> FailEarlyAsync_ROP()
	{
		var result = await Fraction.UpdateRankAsync_ROP(Guid.Empty, Guid.Empty, Guid.Empty);
		return result.IsSuccess ? 1 : 0;
	}

	[Benchmark]
	public async Task<int> FailEarlyAsync_Exception()
	{
		try
		{
			await Fraction.UpdateRankAsync_Exception(Guid.Empty, Guid.Empty, Guid.Empty);
			return 1;
		}
		catch
		{
			return 0;
		}
	}

	[Benchmark]
	public async Task<int> FailLateAsync_RP()
	{
		var result = await Fraction.UpdateRankAsync_RP(MemberSeeds.JediWindu.Id, MemberSeeds.JediKenobi.Id, RankSeeds.JediGrandMaster.Id);
		return result.IsSuccess ? 1 : 0;
	}

	[Benchmark]
	public async Task<int> FailLateAsync_ROP()
	{
		var result = await Fraction.UpdateRankAsync_ROP(MemberSeeds.JediWindu.Id, MemberSeeds.JediKenobi.Id, RankSeeds.JediGrandMaster.Id);
		return result.IsSuccess ? 1 : 0;
	}

	[Benchmark]
	public async Task<int> FailLateAsync_Exception()
	{
		try
		{
			await Fraction.UpdateRankAsync_Exception(MemberSeeds.JediWindu.Id, MemberSeeds.JediKenobi.Id, RankSeeds.JediGrandMaster.Id);
			return 1;
		}
		catch
		{
			return 0;
		}
	}
}
