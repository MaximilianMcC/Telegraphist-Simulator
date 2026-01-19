using Raylib_cs;

class Training
{
	private static WpmTimings wpm;
	private static ContinuousWave continuousWave;

	private static bool generatedLetter;
	private static string morseLetter;
	private static string englishLetter;

	public static void Start()
	{
		wpm = new WpmTimings(10);

		continuousWave = new ContinuousWave(440);
		MorseCodePlayer.ContinuousWave = continuousWave;
	}

	public static void Update()
	{
		// Press space for letter
		if (Raylib.IsKeyPressed(KeyboardKey.Space))
		{
			// If there is no letter then make a new one
			if (generatedLetter == false)
			{
				// Get a random letter in both Morse and English
				morseLetter = MorseCodeConverter.GetRandomMorseLetter();
				englishLetter = MorseCodeConverter.MorseToEnglish(morseLetter);
				generatedLetter = true;
			}

			// Play the letter
			MorseCodePlayer.SendFromMorse(morseLetter, wpm);
		}

		if (generatedLetter)
		{
			// Listen for if we've selected the correct letter
			KeyboardKey letter = ((KeyboardKey)englishLetter[0]);
			if (Raylib.IsKeyPressed(letter))
			{
				// Correct
				Console.WriteLine("correct");
				generatedLetter = false;
			}
		}

	}

	public static void Render()
	{
		if (MorseCodePlayer.SendingRn)
		{
			Utils.DrawCentreText(englishLetter, 60f);
		}
	}
}