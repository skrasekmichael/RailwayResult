using RailwayResult.FunctionalExtensions.Benchmarks.Extensions;

namespace RailwayResult.FunctionalExtensions.Benchmarks.Data;

public sealed partial class Fraction
{
	public Result<FractionMember> GetMemberByBeingId_ROP(Guid beingId)
	{
		return Members
			.FirstOrDefault(m => m.BeingId == beingId)
			.EnsureNotNull(BeingNotMemberOfFraction);
	}

	public Result<FractionMember> GetMemberById_ROP(Guid memberId)
	{
		return Members
			.FirstOrDefault(m => m.Id == memberId)
			.EnsureNotNull(MemberNotFound);
	}

	public Result<Rank> GetRankById_ROP(Guid rankId)
	{
		return Ranks
			.FirstOrDefault(r => r.Id == rankId)
			.EnsureNotNull(RankNotFound);
	}

	public Result UpdateRank_ROP(Guid initiatorBeingId, Guid targetMemberId, Guid newRankId)
	{
		return GetMemberByBeingId_ROP(initiatorBeingId)
			.Ensure(initiatorMember => initiatorMember.Rank.Permissions.HasFlag(Permission.UpdateRank), CannotUpdateRanks)
			.Then(_ => GetMemberById_ROP(targetMemberId))
			.Ensure(target => !target.Rank.IsHeadOfFraction, CannotUpdateRankOfHeadOfFraction)
			.And(() => GetRankById_ROP(newRankId))
			.Ensure((_, newRank) => !newRank.IsHeadOfFraction, CannotHaveMultipleHeads)
			.Tap((targetMember, newRank) => targetMember.Rank = newRank)
			.ToResult();
	}

	public Task<Result<FractionMember>> GetMemberByBeingIdAsync_ROP(Guid beingId)
	{
		return Members
			.FirstOrDefaultAsync(m => m.BeingId == beingId)
			.EnsureNotNull(BeingNotMemberOfFraction);
	}

	public Task<Result<FractionMember>> GetMemberByIdAsync_ROP(Guid memberId)
	{
		return Members
			.FirstOrDefaultAsync(m => m.Id == memberId)
			.EnsureNotNull(MemberNotFound);
	}

	public Task<Result<Rank>> GetRankByIdAsync_ROP(Guid rankId)
	{
		return Ranks
			.FirstOrDefaultAsync(r => r.Id == rankId)
			.EnsureNotNull(RankNotFound);
	}

	public Task<Result> UpdateRankAsync_ROP(Guid initiatorBeingId, Guid targetMemberId, Guid newRankId)
	{
		return GetMemberByBeingIdAsync_ROP(initiatorBeingId)
			.Ensure(initiatorMember => initiatorMember.Rank.Permissions.HasFlag(Permission.UpdateRank), CannotUpdateRanks)
			.ThenAsync(_ => GetMemberByIdAsync_ROP(targetMemberId))
			.Ensure(target => !target.Rank.IsHeadOfFraction, CannotUpdateRankOfHeadOfFraction)
			.AndAsync(_ => GetRankByIdAsync_ROP(newRankId))
			.Ensure((_, newRank) => !newRank.IsHeadOfFraction, CannotHaveMultipleHeads)
			.Tap((targetMember, newRank) => targetMember.Rank = newRank)
			.ToResultAsync();
	}
}
