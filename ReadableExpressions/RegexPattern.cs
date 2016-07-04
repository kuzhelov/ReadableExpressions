using System;
using System.Collections.Generic;

namespace ReadableExpressions
{
	public class RegexPattern
	{
		public static RegexPattern Create(
			Func<RegexElementsProvider, IEnumerable<RegexPattern>> getTokens)
		{
			return Create(fromTokens: getTokens(_regexElementsProvider));
		}

		public static RegexPattern Create(
			IEnumerable<RegexPattern> fromTokens)
		{
			return string.Join(
				separator: string.Empty,
				values: fromTokens);
		}

		private RegexPattern(string pattern)
		{
			_pattern = pattern;
		}

		public override string ToString()
		{
			return _pattern;
		}

		public static implicit operator RegexPattern(string pattern)
		{
			return new RegexPattern(pattern);
		}

		private static readonly RegexElementsProvider _regexElementsProvider = new RegexElementsProvider();

		private readonly string _pattern;
	}
}