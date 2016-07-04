namespace ReadableExpressions.Extensions
{
	public static class RegexPatternExtensions
	{
		public static RegexPattern EnsureStartsWith(
			this RegexPattern thisPattern,
			RegexPattern pattern)
		{
			return RegexPattern.Create(
				fromTokens: new[]
				{
					RegexAssertion.PositiveLookAhead(pattern),
					thisPattern
				});
		}

		public static RegexPattern EnsureNotStartsWith(
			this RegexPattern thisPattern,
			RegexPattern pattern)
		{
			return RegexPattern.Create(
				fromTokens: new[]
				{
					RegexAssertion.NegativeLookAhead(pattern),
					thisPattern
				});
		}

		public static RegexPattern EnsureNotEndsWith(
			this RegexPattern thisPattern,
			RegexPattern pattern)
		{
			return RegexPattern.Create(
				fromTokens: new[]
				{
					thisPattern,
					RegexAssertion.NegativeLookBehind(pattern)
				});
		}

		public static RegexPattern EnsureNotFollowedBy(
			this RegexPattern thisPattern,
			RegexPattern pattern)
		{
			return RegexPattern.Create(
				fromTokens: new[]
				{
					thisPattern,
					RegexAssertion.NegativeLookAhead(forPattern: pattern)
				});
		}

		public static RegexPattern Repeated(
			this RegexPattern thisPattern,
			int atLeast,
			int atMost)
		{
			return RegexPattern.Create(
				fromTokens: new[]
				{
					thisPattern,
					RegexQuantifier.Repeat(
						atLeast: atLeast,
						atMost: atMost)
				});
		}

		public static RegexPattern RepeatedOneOrMoreTimes(
			this RegexPattern thisPattern)
		{
			return RegexPattern.Create(
				fromTokens: new[]
				{
					thisPattern,
					RegexQuantifier.OneOrMoreTimes
				});
		}
	}
}