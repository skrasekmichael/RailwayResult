namespace RailwayResult.FunctionalExtensions.Benchmarks.Data;

[Flags]
public enum Permission
{
	None,
	InviteCandidate,
	AcceptCandidate,
	ExcommunicateMember,
	UpdateRank,
	CreateRank
}
