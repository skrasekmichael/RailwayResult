using RailwayResult.FunctionalExtensions.Benchmarks.Data;

namespace RailwayResult.FunctionalExtensions.Benchmarks.Seeds;

public static class MemberSeeds
{
	public static readonly FractionMember JediYoda = new()
	{
		Id = new("be8d50e4-fe9d-4833-b9cf-30d01cda5226"),
		BeingId = BeingSeeds.Yoda.Id,
		Name = "Master Yoda",
		Rank = RankSeeds.JediMaster
	};

	public static readonly FractionMember JediWindu = new()
	{
		Id = new("1f52ccfb-92d5-4105-beaa-b3c5aaa1fe58"),
		BeingId = BeingSeeds.MaceWindu.Id,
		Name = "Master Windu",
		Rank = RankSeeds.JediGrandMaster
	};

	public static readonly FractionMember JediKenobi = new()
	{
		Id = new("ce74c501-267d-4338-9274-54a3aea62ad8"),
		BeingId = BeingSeeds.ObiWanKenobi.Id,
		Name = "Master Kenobi",
		Rank = RankSeeds.JediMaster
	};

	public static readonly FractionMember JediSkywalker = new()
	{
		Id = new("484b01c4-b2cb-4ea0-8a5a-2ddbb747c335"),
		BeingId = BeingSeeds.AnakinSkywalker.Id,
		Name = "Skywalker",
		Rank = RankSeeds.JediKnight
	};

	public static readonly FractionMember JediFisto = new()
	{
		Id = new("f21aa018-28ed-4646-9637-d7a1a421995e"),
		BeingId = BeingSeeds.KitFisto.Id,
		Name = "Kit Fisto",
		Rank = RankSeeds.JediKnight
	};
}
