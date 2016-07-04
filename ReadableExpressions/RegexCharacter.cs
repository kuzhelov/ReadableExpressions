namespace ReadableExpressions
{
	public class RegexCharacter
	{
		public static readonly RegexCharacter Digit = new RegexCharacter("0-9");
		public static readonly RegexCharacter LetterOrDigit = new RegexCharacter(@"\w");
		public static readonly RegexCharacter LowerCaseASCIILetter = new RegexCharacter("a-z");
		public static readonly RegexCharacter UpperCaseASCIILetter = new RegexCharacter("A-Z");
		public static readonly RegexCharacter ASCIILetter = LowerCaseASCIILetter.Or(UpperCaseASCIILetter);

		public static RegexPattern Any => ".";

		public static RegexCharacter Literal(char character)
		{
			return new RegexCharacter(
				pattern: EnsureEscaped(character));
		}

		private RegexCharacter(string pattern)
		{
			_pattern = pattern;
		}

		public RegexCharacter Or(RegexCharacter other)
		{
			return new RegexCharacter(_pattern + other._pattern);
		}

		public static implicit operator RegexPattern(RegexCharacter character)
		{
			return "[" + character._pattern + "]";
		}

		private static string EnsureEscaped(char character)
		{
			return SpecialCharacters.Contains(character.ToString())
				? @"\" + character
				: character.ToString();
		}

		private const string SpecialCharacters = @"^-]\";

		private readonly string _pattern;
	}
}