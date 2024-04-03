using RailwayResult.FunctionalExtensions.Benchmarks.Extensions;

namespace RailwayResult.FunctionalExtensions.Benchmarks.Data;

public sealed partial class Fraction
{
	public Result<FractionMember> GetMemberByBeingId_RP(Guid beingId)
	{
		var member = Members.FirstOrDefault(m => m.BeingId == beingId);
		if (member is null)
			return BeingNotMemberOfFraction;

		return member;
	}

	public Result<FractionMember> GetMemberById_RP(Guid memberId)
	{
		var member = Members.FirstOrDefault(m => m.Id == memberId);
		if (member is null)
			return MemberNotFound;

		return member;
	}

	public Result<Rank> GetRankById_RP(Guid rankId)
	{
		var rank = Ranks.FirstOrDefault(r => r.Id == rankId);
		if (rank is null)
			return RankNotFound;

		return rank;
	}

	public Result UpdateRank_RP(Guid initiatorBeingId, Guid targetMemberId, Guid newRankId)
	{
		var initiatorResult = GetMemberByBeingId_RP(initiatorBeingId);
		if (initiatorResult.IsFailure)
			return BeingNotMemberOfFraction;

		if (!initiatorResult.Value.Rank.Permissions.HasFlag(Permission.UpdateRank))
			return CannotUpdateRanks;

		var targetMemberResult = GetMemberById_RP(targetMemberId);
		if (targetMemberResult.IsFailure)
			return MemberNotFound;

		if (targetMemberResult.Value.Rank.IsHeadOfFraction)
			return CannotUpdateRankOfHeadOfFraction;

		var newRankResult = GetRankById_RP(newRankId);
		if (newRankResult.IsFailure)
			return RankNotFound;

		if (newRankResult.Value.IsHeadOfFraction)
			return CannotHaveMultipleHeads;

		targetMemberResult.Value.Rank = newRankResult.Value;
		return Result.Success;
	}

	public async Task<Result<FractionMember>> GetMemberByBeingIdAsync_RP(Guid beingId)
	{
		var member = await Members.FirstOrDefaultAsync(m => m.BeingId == beingId);
		if (member is null)
			return BeingNotMemberOfFraction;

		return member;
	}

	public async Task<Result<FractionMember>> GetMemberByIdAsync_RP(Guid memberId)
	{
		var member = await Members.FirstOrDefaultAsync(m => m.Id == memberId);
		if (member is null)
			return MemberNotFound;

		return member;
	}

	public async Task<Result<Rank>> GetRankByIdAsync_RP(Guid rankId)
	{
		var rank = await Ranks.FirstOrDefaultAsync(r => r.Id == rankId);
		if (rank is null)
			return RankNotFound;

		return rank;
	}

	public async Task<Result> UpdateRankAsync_RP(Guid initiatorBeingId, Guid targetMemberId, Guid newRankId)
	{
		var initiatorResult = await GetMemberByBeingIdAsync_RP(initiatorBeingId);
		if (initiatorResult.IsFailure)
			return BeingNotMemberOfFraction;

		if (!initiatorResult.Value.Rank.Permissions.HasFlag(Permission.UpdateRank))
			return CannotUpdateRanks;

		var targetMemberResult = await GetMemberByIdAsync_RP(targetMemberId);
		if (targetMemberResult.IsFailure)
			return MemberNotFound;

		if (targetMemberResult.Value.Rank.IsHeadOfFraction)
			return CannotUpdateRankOfHeadOfFraction;

		var newRankResult = await GetRankByIdAsync_RP(newRankId);
		if (newRankResult.IsFailure)
			return RankNotFound;

		if (newRankResult.Value.IsHeadOfFraction)
			return CannotHaveMultipleHeads;

		targetMemberResult.Value.Rank = newRankResult.Value;
		return Result.Success;
	}
}
