class MorseCode
{
	public static void Play(string text, WpmTimings wpm)
	{
		// Turn the text into morse
		string morseString = MorseCodeConverter.EnglishToMorseString(text);

		// Store the sounds we gotta make
		List<Timing> timings = new List<Timing>();

		// Loop over each character
		for (int i = 0; i < morseString.Length; i++)
		{
			// Check for what we are
			// TODO: wpm.GetDuration('.') then use a dictionary or smth
			switch (morseString[i])
			{
				case '.':
					timings.Add(new Timing(false, wpm.Dit));
					break;

				case '-':
					timings.Add(new Timing(false, wpm.Dah));
					break;

				case ' ':
					timings.Add(new Timing(true, wpm.LetterGap));
					break;

				case '/':
					timings.Add(new Timing(true, wpm.Space));
					break;
			}

			// If it was a dit or dah and there is something
			// in front then also add a key gap
			if ((morseString[i] == '.' || morseString[i] == '-') && i < morseString.Length)
			{
				timings.Add(new Timing(true, wpm.KeyGap));
			}	
		}
	}

	public static void Update()
	{
		
	}
}

// TODO: Don't do this and just use a tuple instead
struct Timing
{
	public bool Gap { get; private set; }
	public float Duration { get; private set; }

	public Timing(bool isGap, float duration)
	{
		Gap = isGap;
		Duration = duration;
	}
}

struct WpmTimings
{
	public float Dit { get; }
	public float Dah { get; }
	public float KeyGap { get; } //? Time between each dit/dah in a letter
	public float LetterGap { get; }
	public float Space { get; }

	public WpmTimings(float wpm)
	{
		//? 1.2 is the paris standard (how long it takes to morse PARIS)
		float dit = 1.2f / wpm;
		
		Dit = dit;
		Dah = dit * 3;
		KeyGap = dit;
		LetterGap = dit * 3;
		Space = dit * 7;
	}
}