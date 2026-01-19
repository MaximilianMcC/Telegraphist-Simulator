class MorseCodeConverter
{
	public static readonly Dictionary<char, string> MorseDictionary = new Dictionary<char, string>
	{
		{ 'A', ".-" },
		{ 'B', "-..." },
		{ 'C', "-.-." },
		{ 'D', "-.." },
		{ 'E', "." },
		{ 'F', "..-." },
		{ 'G', "--." },
		{ 'H', "...." },
		{ 'I', ".." },
		{ 'J', ".---" },
		{ 'K', "-.-" },
		{ 'L', ".-.." },
		{ 'M', "--" },
		{ 'N', "-." },
		{ 'O', "---" },
		{ 'P', ".--." },
		{ 'Q', "--.-" },
		{ 'R', ".-." },
		{ 'S', "..." },
		{ 'T', "-" },
		{ 'U', "..-" },
		{ 'V', "...-" },
		{ 'W', ".--" },
		{ 'X', "-..-" },
		{ 'Y', "-.--" },
		{ 'Z', "--.." },
		{ ' ', "/" }
	};

	public static string EnglishToMorseString(string english)
	{
		// No capitalisation differences
		english = english.ToUpper();

		string output = "";
		foreach (char character in english.ToCharArray())
		{
			output += MorseDictionary[character] + " ";
		}

		// Give back the morse code string representation
		// (also remove the left over ' ' at the end)
		return output.TrimEnd(' ');
	}

	public static string MorseToEnglish(string morse)
	{
		string output = "";
		foreach (string morseLetter in morse.Split(" "))
		{
			char englishLetter = MorseDictionary.FirstOrDefault(letter => letter.Value == morseLetter).Key;
			output += englishLetter;
		}

		return output;
	}

	public static char GetRandomEnglishLetter()
	{
		//? -2 because we do not want the last one (space)
		Random random = new Random();
		return MorseDictionary.Keys.ToList()[random.Next(0, MorseDictionary.Count - 2)];
	}

	public static string GetRandomMorseLetter()
	{
		//? -2 because we do not want the last one (space)
		Random random = new Random();
		return MorseDictionary.Values.ToList()[random.Next(0, MorseDictionary.Count - 2)];
	}
}