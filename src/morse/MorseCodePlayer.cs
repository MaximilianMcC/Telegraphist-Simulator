using Raylib_cs;

class MorseCodePlayer
{
	public static bool SendingRn { get; private set; }
	public static ContinuousWave ContinuousWave { get; set; }

	private static List<Timing> timings;
	private static int timingIndex;
	private static double startTime;

	public static void SendFromEnglish(string text, WpmTimings wpm)
	{
		// Turn the text into morse first
		string morseString = MorseCodeConverter.EnglishToMorseString(text);
		Send(morseString, wpm);
	}

	public static void SendFromMorse(string text, WpmTimings wpm)
	{
		Send(text, wpm);
	}

	// Works with morse
	private static void Send(string morseString, WpmTimings wpm)
	{
		// Can only send one at once
		// TODO: Make this instanced to avoid this
		if (SendingRn)
		{
			Console.WriteLine("Can only send one thing at a time");
			return;
		}

		// Store the sounds we gotta make
		timings = new List<Timing>();

		// Loop over each character
		for (int i = 0; i < morseString.Length; i++)
		{
			Console.WriteLine(morseString[i]);
			
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

		SendingRn = true;
		timingIndex = 0;
		startTime = Raylib.GetTime();
	}

	public static void Update()
	{
		if (SendingRn == false) return;

		// Check for if we've finished
		if (timingIndex >= timings.Count)
		{
			SendingRn = false;
			return;
		}

		// Check for if we must play a sound or stay quiet
		if (timings[timingIndex].Gap == false) ContinuousWave.PlayContinuously();

		// Check for if we need to move onto the
		// next timing section thingy
		double elapsedTime = Raylib.GetTime() - startTime;
		if (elapsedTime >= timings[timingIndex].Duration)
		{
			timingIndex++;
			startTime = Raylib.GetTime();
		}
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

	// TODO: remove (debug)
	public override string ToString()
	{
		return
			$"Dit: {Dit}" +
			$"\nDah: {Dah}" +
			$"\nKeyGap: {KeyGap}" +
			$"\nLetterGap: {LetterGap}" +
			$"\nSpace: {Space}";
	}
}