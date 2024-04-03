using RailwayResult.FunctionalExtensions.Benchmarks.Data;

namespace RailwayResult.FunctionalExtensions.Benchmarks.Seeds;

public static class RankSeeds
{
	public static readonly Rank JediGrandMaster = new()
	{
		Id = new("85225774-d24f-4bb7-90e8-a696665b63fd"),
		Name = "Grand Master",
		Permissions = Permission.InviteCandidate | Permission.AcceptCandidate | Permission.ExcommunicateMember | Permission.UpdateRank | Permission.CreateRank,
		IsHeadOfFraction = true,
	};

	public static readonly Rank JediMaster = new()
	{
		Id = new("d612787c-38cd-4fc3-8083-5e357e951b0a"),
		Name = "Master",
		Permissions = Permission.InviteCandidate | Permission.AcceptCandidate
	};

	public static readonly Rank JediKnight = new()
	{
		Id = new("17d7660d-7154-408f-b2c8-55fd2d4d6e10"),
		Name = "Knight",
		Permissions = Permission.InviteCandidate
	};

	public static readonly Rank JediPadawan = new()
	{
		Id = new("5cfb2ea6-ef46-4495-9e42-afb03df42ec9"),
		Name = "Padawan",
		Permissions = Permission.None
	};
}
