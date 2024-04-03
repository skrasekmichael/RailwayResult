using RailwayResult.FunctionalExtensions.Benchmarks.Data;

namespace RailwayResult.FunctionalExtensions.Benchmarks.Seeds;

public static class FractionSeeds
{
	public static readonly Fraction JediOrder = new()
	{
		Id = new("5fef9d92-17b4-4f63-b19d-e81d104422ca"),
		Name = "Jedi Order",
		Members = [
			MemberSeeds.JediSkywalker,
			MemberSeeds.JediKenobi,
			MemberSeeds.JediYoda,
			MemberSeeds.JediFisto,
			MemberSeeds.JediWindu,
		],
		Ranks = [RankSeeds.JediGrandMaster, RankSeeds.JediMaster, RankSeeds.JediKnight, RankSeeds.JediPadawan],
		Tags = [TagSeeds.LightSide]
	};
}
