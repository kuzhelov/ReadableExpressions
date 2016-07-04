using System.Collections.Generic;

namespace ReadableExpressions
{
	public class RegexElementsProvider
	{
		public RegexPattern LineStart => RegexAnchor.LineStart;

		public RegexPattern LineEnd => RegexAnchor.LineEnd;

		public RegexCharacter Literal(char character) => RegexCharacter.Literal(character);

		public RegexCharacter Digit => RegexCharacter.Digit;

		public RegexCharacter ASCIILetter => RegexCharacter.ASCIILetter;

		public RegexCharacter ASCIILetterOrDigit => ASCIILetter.Or(Digit);

		public RegexCharacter LetterOrDigit => RegexCharacter.LetterOrDigit;

		public RegexPattern AnyCharacter => RegexCharacter.Any;

		public RegexPattern Group(IEnumerable<RegexPattern> withTokens) =>
			RegexGroup.Create(withPattern: RegexPattern.Create(withTokens));

		public RegexPattern Group(
			string withName,
			RegexPattern withPattern)
		{
			return RegexGroup.Create(
				withName: withName,
				withPattern: withPattern);
		}

		public RegexPattern Group(
			string withName,
			IEnumerable<RegexPattern> withTokens)
		{
			return Group(
				withName: withName,
				withPattern: RegexPattern.Create(withTokens));
		}

		public RegexPattern OptionalGroup(
			string withName,
			RegexPattern withPattern)
		{
			return RegexPattern.Create(
				fromTokens: new[]
				{
					Group(
						withName: withName,
						withPattern: withPattern),
					RegexQuantifier.ZeroOrOneTimes
				});
		}

		public RegexPattern OptionalGroup(
			string withName,
			IEnumerable<RegexPattern> withTokens)
		{
			return OptionalGroup(
				withName: withName,
				withPattern: RegexPattern.Create(fromTokens: withTokens));
		}

		public RegexPattern RepetitiveGroup(
			string withName,
			IEnumerable<RegexPattern> withTokens)
		{
			return RegexPattern.Create(
				fromTokens: new[]
				{
					Group(
						withName: withName,
						withTokens: withTokens),
					RegexQuantifier.OneOrMoreTimes
				});
		}

		public RegexPattern Pattern(string pattern) => pattern;

		public RegexPattern Pattern(IEnumerable<RegexPattern> withTokens) => RegexPattern.Create(withTokens);

		public RegexPattern EnsureIsPrecededWith(RegexPattern pattern) =>
			RegexAssertion.PositiveLookBehind(forPattern: pattern);

		public RegexPattern EnsureIsFollowedBy(IEnumerable<RegexPattern> tokens) => 
			RegexAssertion.PositiveLookAhead(forPattern: RegexPattern.Create(tokens));

		public RegexPattern EnsureNotFollowedBy(RegexPattern pattern) => 
			RegexAssertion.NegativeLookAhead(forPattern: pattern);

		public RegexPattern EnsureNotPrecededWith(RegexPattern pattern) =>
			RegexAssertion.NegativeLookBehind(forPattern: pattern);
	}
}