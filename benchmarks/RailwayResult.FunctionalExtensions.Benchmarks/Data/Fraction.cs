namespace RailwayResult.FunctionalExtensions.Benchmarks.Data;

public sealed partial class Fraction
{
	public static readonly GenericError BeingNotMemberOfFraction = new("Being is not member of fraction.");
	public static readonly GenericError MemberNotFound = new("Member not found.");
	public static readonly GenericError RankNotFound = new("Rank not found.");
	public static readonly GenericError CannotUpdateRanks = new("Cannot update ranks.");
	public static readonly GenericError CannotUpdateRankOfHeadOfFraction = new("Cannot change rank of head of fraction.");
	public static readonly GenericError CannotHaveMultipleHeads = new("Fraction cannot have multiple heads.");

	public required Guid Id { get; init; }
	public required string Name { get; set; }

	public List<FractionMember> Members { get; init; } = [];
	public List<Rank> Ranks { get; init; } = [];
	public List<Tag> Tags { get; init; } = [];
}
