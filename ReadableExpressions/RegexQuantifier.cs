namespace ReadableExpressions
{
	public static class RegexQuantifier
	{
		public static RegexPattern ZeroOrOneTimes => "?";

		public static RegexPattern ZeroOrMoreTimes => "*";

		public static RegexPattern OneOrMoreTimes => "+";

		public static RegexPattern FixedNumberOfTimes(int numberOfTimes)
		{
			return "{" + numberOfTimes + "}";
		}

		public static RegexPattern Repeat(int atLeast, int atMost)
		{
			return "{" + atLeast + "," + atMost + "}";
		}
	}
}