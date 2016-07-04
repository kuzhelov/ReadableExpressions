namespace ReadableExpressions.Extensions
{
	public static class RegexCharacterExtensions
	{
		public static RegexPattern Repeated(
			this RegexCharacter thisCharacter,
			int atLeast,
			int atMost)
		{
			return ((RegexPattern)thisCharacter)
				.Repeated(atLeast: atLeast, atMost: atMost);
		}

		public static RegexPattern RepeatedOneOrMoreTimes(
			this RegexCharacter thisCharacter)
		{
			return ((RegexPattern)thisCharacter).RepeatedOneOrMoreTimes();
		}

		public static RegexPattern EnsureStartsWith(
			this RegexCharacter thisCharacter,
			RegexPattern pattern)
		{
			return ((RegexPattern)thisCharacter)
				.EnsureStartsWith(pattern: pattern);
		}

		public static RegexPattern EnsureNotStartsWith(
			this RegexCharacter thisCharacter,
			RegexPattern pattern)
		{
			return ((RegexPattern)thisCharacter)
				.EnsureNotStartsWith(pattern: pattern);
		}

		public static RegexPattern EnsureNotFollowedBy(
			this RegexCharacter thisCharacter,
			RegexPattern pattern)
		{
			return ((RegexPattern)thisCharacter)
				.EnsureNotFollowedBy(pattern: pattern);
		}

		public static RegexPattern EnsureNotEndsWith(
			this RegexCharacter thisCharacter,
			RegexPattern pattern)
		{
			return ((RegexPattern)thisCharacter)
				.EnsureNotEndsWith(pattern: pattern);
		}
	}
}