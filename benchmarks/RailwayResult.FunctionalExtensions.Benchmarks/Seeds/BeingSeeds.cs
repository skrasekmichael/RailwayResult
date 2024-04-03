using RailwayResult.FunctionalExtensions.Benchmarks.Data;

namespace RailwayResult.FunctionalExtensions.Benchmarks.Seeds;

public static class BeingSeeds
{
	public static readonly Being Yoda = new()
	{
		Id = new Guid("fd37e883-86fa-4ca5-9c6a-d527fa69d920"),
		Name = "Yoda"
	};

	public static readonly Being ObiWanKenobi = new()
	{
		Id = new Guid("bda7ed6e-f690-4c4f-94d3-8e4af455d7f9"),
		Name = "Obi-Wan Kenobi"
	};

	public static readonly Being Vader = new()
	{
		Id = new Guid("1ad5034f-714a-4a8b-97b2-45a6165b029f"),
		Name = "Vader"
	};

	public static readonly Being AnakinSkywalker = new()
	{
		Id = new Guid("58d11013-8c7e-48cf-ad13-4b9d51d0c319"),
		Name = "Anakin Skywalker"
	};

	public static readonly Being KitFisto = new()
	{
		Id = new Guid("8a1db189-f8b3-411c-b77e-3f62fa424f84"),
		Name = "Kit Fisto"
	};

	public static readonly Being MaceWindu = new()
	{
		Id = new Guid("99dbeaee-8a47-4d70-9bdd-219ec66c26e6"),
		Name = "Mace Windu"
	};
}
