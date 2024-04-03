using RailwayResult.FunctionalExtensions.Benchmarks.Extensions;

namespace RailwayResult.FunctionalExtensions.Benchmarks.Data;

public sealed partial class Fraction
{
	public FractionMember GetMemberByBeingId_Exception(Guid beingId)
	{
		var member = Members.FirstOrDefault(m => m.BeingId == beingId);
		if (member is null)
			throw new Exception(BeingNotMemberOfFraction.Message);

		return member;
	}

	public FractionMember GetMemberById_Exception(Guid memberId)
	{
		var member = Members.FirstOrDefault(m => m.Id == memberId);
		if (member is null)
			throw new Exception(MemberNotFound.Message);

		return member;
	}

	public Rank GetRankById_Exception(Guid rankId)
	{
		var rank = Ranks.FirstOrDefault(r => r.Id == rankId);
		if (rank is null)
			throw new Exception(RankNotFound.Message);

		return rank;
	}

	public void UpdateRank_Exception(Guid initiatorBeingId, Guid targetMemberId, Guid newRankId)
	{
		var initiator = GetMemberByBeingId_Exception(initiatorBeingId);
		if (!initiator.Rank.Permissions.HasFlag(Permission.UpdateRank))
			throw new Exception(CannotUpdateRanks.Message);

		var targetMember = GetMemberById_Exception(targetMemberId);
		if (targetMember.Rank.IsHeadOfFraction)
			throw new Exception(CannotUpdateRankOfHeadOfFraction.Message);

		var newRank = GetRankById_Exception(newRankId);
		if (newRank.IsHeadOfFraction)
			throw new Exception(CannotHaveMultipleHeads.Message);

		targetMember.Rank = newRank;
	}

	public async Task<FractionMember> GetMemberByBeingIdAsync_Exception(Guid beingId)
	{
		var member = await Members.FirstOrDefaultAsync(m => m.BeingId == beingId);
		if (member is null)
			throw new Exception(BeingNotMemberOfFraction.Message);

		return member;
	}

	public async Task<FractionMember> GetMemberByIdAsync_Exception(Guid memberId)
	{
		var member = await Members.FirstOrDefaultAsync(m => m.Id == memberId);
		if (member is null)
			throw new Exception(MemberNotFound.Message);

		return member;
	}

	public async Task<Rank> GetRankByIdAsync_Exception(Guid rankId)
	{
		var rank = await Ranks.FirstOrDefaultAsync(r => r.Id == rankId);
		if (rank is null)
			throw new Exception(RankNotFound.Message);

		return rank;
	}

	public async Task UpdateRankAsync_Exception(Guid initiatorBeingId, Guid targetMemberId, Guid newRankId)
	{
		var initiator = await GetMemberByBeingIdAsync_Exception(initiatorBeingId);
		if (!initiator.Rank.Permissions.HasFlag(Permission.UpdateRank))
			throw new Exception(CannotUpdateRanks.Message);

		var targetMember = await GetMemberByIdAsync_Exception(targetMemberId);
		if (targetMember.Rank.IsHeadOfFraction)
			throw new Exception(CannotUpdateRankOfHeadOfFraction.Message);

		var newRank = await GetRankByIdAsync_Exception(newRankId);
		if (newRank.IsHeadOfFraction)
			throw new Exception(CannotHaveMultipleHeads.Message);

		targetMember.Rank = newRank;
	}
}
