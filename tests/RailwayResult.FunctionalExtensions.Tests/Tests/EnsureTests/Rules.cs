﻿using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.EnsureTests;

public static class Rules
{
	public static readonly Rule<O> IsNullOrWhiteSpaceRule = o => string.IsNullOrWhiteSpace(o.Value);
	public static readonly Rule<O> RuleException = _ => BasicException.Throw<bool>();

	public static readonly RuleWithError<O> IsNullOrWhiteSpace = new(IsNullOrWhiteSpaceRule, Errors.ErrorA);
	public static readonly RuleWithError<O> IsNotNullOrWhiteSpace = new(s => !IsNullOrWhiteSpaceRule(s), Errors.ErrorA);
	public static readonly RuleWithError<O> IsEmpty = new(o => string.IsNullOrEmpty(o.Value), Errors.ErrorB);

	public static RuleWithError<O> CountIs(int len) => new(s => s.Value?.Length == len, Errors.ErrorC);
	public static RuleWithError<(O A, O B)> CountIs(int l1, int l2) => new(context => context.A.Value?.Length == l1 && context.B.Value?.Length == l2, Errors.ErrorC);

	public static readonly RuleWithError<O> ORuleWithErrorException = new(_ => BasicException.Throw<bool>(), Errors.ErrorA);
	public static readonly RuleWithError<(O, O)> OORuleWithErrorException = new(_ => BasicException.Throw<bool>(), Errors.ErrorA);
}
