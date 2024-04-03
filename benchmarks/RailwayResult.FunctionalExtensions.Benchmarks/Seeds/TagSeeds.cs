using RailwayResult.FunctionalExtensions.Benchmarks.Data;

namespace RailwayResult.FunctionalExtensions.Benchmarks.Seeds;

public static class TagSeeds
{
	public static readonly Tag LightSide = new()
	{
		Id = new("fc5bf11b-ca89-4bd6-b936-55a0aa5bbda4"),
		Name = "Light Side of the Force"
	};

	public static readonly Tag DarkSide = new()
	{
		Id = new("2215a8b8-36cc-4ed5-8176-a60cc7b8fa12"),
		Name = "Dark Side of the Force"
	};
}
