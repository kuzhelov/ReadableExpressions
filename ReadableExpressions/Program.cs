using System;
using System.Text.RegularExpressions;
using ReadableExpressions.Extensions;

namespace ReadableExpressions
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var inputs = new[]
			{
				"general.example.com",
				"4valid.ru",
				"valid-with.optional.dot.",
				"invalid-top-domain.d",
				"invalid-with-no-top-domain",
				"invalid.domain-with-numbers.in-top.3rd"
			};

			foreach (var input in inputs)
			{
				Console.WriteLine($"{input} is FQDN? {Regex.IsMatch(input: input, pattern: FqdnPattern)}");
			}
		}

		// it becomes pretty easy to build (while literally transforming business rules into code)
		// and, what is more important, maintain and reason about regular expression patterns
		private static readonly string FqdnPattern = RegexPattern.Create(
			getTokens: _ => new[]
			{
				_.EnsureIsFollowedBy(
					tokens: new[]
					{
						_.LineStart,
						_.AnyCharacter.Repeated(atLeast: 4, atMost: 253),
						_.LineEnd
					}),
				_.LineStart,
				_.Group(
					withName: "main",
					withTokens: new[]
					{
						_.RepetitiveGroup(
							withName: "token",
							withTokens: new[]
							{
								_.ASCIILetterOrDigit.Or(_.Literal('-'))
									.Repeated(atLeast: 1, atMost: 63)
									.EnsureNotStartsWith(pattern: _.Literal('-'))
									.EnsureNotEndsWith(pattern: _.Literal('-')),
								_.Literal('.')
							}),
					}),
				_.Group(
					withName: "top",
					withTokens: new[]
					{
						_.ASCIILetterOrDigit.Or(_.Literal('-'))
							.Repeated(atLeast: 2, atMost: 63)
							.EnsureNotStartsWith(pattern: _.Digit.Or(_.Literal('-')))
							.EnsureNotEndsWith(pattern: _.Literal('-'))
					}),
				_.OptionalGroup(
					withName: "root",
					withPattern: _.Literal('.')),
				_.LineEnd
			})
			.ToString();
	}
}