using Raylib_cs;

static class Input
{
	// TODO: Use wpm class
	private const double DitMax = 0.3;

	private static double keyDownTimestamp;
	private static bool keyDown;

	public static bool Started { get; private set; }
	public static bool Stopped { get; private set; }

	public static double HoldTime => keyDown ? Raylib.GetTime() - keyDownTimestamp : 0;

	// Stuff that is currently happening (KeyDown)
	public static bool DoingDit => keyDown && HoldTime >= 0 && HoldTime < DitMax;
	public static bool DoingDah => keyDown && HoldTime >= DitMax;

	// Stuff that has just been done (KeyPressed)
	public static bool Dit => Stopped && HoldTime < DitMax;
	public static bool Dah => Stopped && HoldTime >= DitMax;

	public static bool KeyDown => keyDown;

	public static void Update()
	{
		// Reset our state
		Started = false;
		Stopped = false;

		// Check for if we are starting a hold
		if (Raylib.IsKeyPressed(KeyboardKey.Space))
		{
			keyDown = true;
			keyDownTimestamp = Raylib.GetTime();
			Started = true;
		}

		// Check for if we are ending a hold
		if (Raylib.IsKeyReleased(KeyboardKey.Space))
		{
			Stopped = true;
			keyDown = false;
		}
	}
}