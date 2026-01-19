class MorseCodeConverter
{
	public static readonly Dictionary<char, string> MorseDictionary = new Dictionary<char, string>
	{
		{'A', ".-"},
		{'B', "-..."},
		{'C', "-.-."},
		{'D', "-.."},
		{'E', "."},
		{'F', "..-."},
		{'G', "--."},
		{'H', "...."},
		{'I', ".."},
		{'J', ".---"},
		{'K', "-.-"},
		{'L', ".-.."},
		{'M', "--"},
		{'N', "-."},
		{'O', "---"},
		{'P', ".--."},
		{'Q', "--.-"},
		{'R', ".-."},
		{'S', "..."},
		{'T', "-"},
		{'U', "..-"},
		{'V', "...-"},
		{'W', ".--"},
		{'X', "-..-"},
		{'Y', "-.--"},
		{'Z', "--.."},
		{'1', ".----"},
		{'2', "..---"},
		{'3', "...--"},
		{'4', "....-"},
		{'5', "....."},
		{'6', "-...."},
		{'7', "--..."},
		{'8', "---.."},
		{'9', "----."},
		{'0', "-----"},
		{'.', ".-.-.-"},
		{',', "--..--"},
		{'?', "..--.."},
		{'\'', ".----."},
		{'!', "-.-.--"},
		{'/', "-..-."},
		{'(', "-.--."},
		{')', "-.--.-"},
		{'&', ".-..."},
		{':', "---..."},
		{';', "-.-.-."},
		{'=', "-...-"},
		{'+', ".-.-."},
		{'-', "-....-"},
		{'_', "..--.-"},
		{'"', ".-..-."},
		{'$', "...-..-"},
		{'@', ".--.-."},
		{' ', "/"}
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
		return "";
	}
}