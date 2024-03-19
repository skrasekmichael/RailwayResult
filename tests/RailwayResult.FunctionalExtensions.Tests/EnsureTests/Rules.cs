namespace RailwayResult.FunctionalExtensions.Tests.EnsureTests;

public static class Rules
{
	public static readonly Rule<string> IsNullOrWhiteSpaceRule = string.IsNullOrWhiteSpace;

	public static readonly RuleWithError<string> IsNullOrWhiteSpace = new(IsNullOrWhiteSpaceRule, Errors.ErrorA);
	public static readonly RuleWithError<string> IsNotNullOrWhiteSpace = new(s => !IsNullOrWhiteSpaceRule(s), Errors.ErrorA);
	public static readonly RuleWithError<string> IsEmpty = new(string.IsNullOrEmpty, Errors.ErrorB);

	public static RuleWithError<string> CountIs(int len) => new(s => s.Length == len, Errors.ErrorC);
	public static RuleWithError<(string A, string B)> CountIs(int l1, int l2) => new(context => context.A.Length == l1 && context.B.Length == l2, Errors.ErrorC);
}
