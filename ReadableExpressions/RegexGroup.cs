namespace ReadableExpressions
{
	public static class RegexGroup
	{
		public static RegexPattern Create(RegexPattern withPattern)
		{
			return string.Format(
				format: "({0})",
				arg0: withPattern);
		}

		public static RegexPattern Create(
			string withName, 
			RegexPattern withPattern)
		{
			return string.Format(
				format: "(?<{0}>{1})",
				arg0: withName,
				arg1: withPattern);
		}
	}
}