namespace ReadableExpressions
{
	public static class RegexAssertion
	{
		public static RegexPattern PositiveLookAhead(RegexPattern forPattern)
		{
			return string.Format(
				format: "(?={0})",
				arg0: forPattern);
		}

		public static RegexPattern NegativeLookAhead(RegexPattern forPattern)
		{
			return string.Format(
				format: "(?!{0})",
				arg0: forPattern);
		}

		public static RegexPattern PositiveLookBehind(RegexPattern forPattern)
		{
			return string.Format(
				format: "(?<={0})",
				arg0: forPattern);
		}

		public static RegexPattern NegativeLookBehind(RegexPattern forPattern)
		{
			return string.Format(
				format: "(?<!{0})",
				arg0: forPattern);
		}
	}
}