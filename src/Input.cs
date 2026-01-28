using Raylib_cs;

static class Input
{
	//! temp
	// TODO: Use wpm paris class thingy
	public static readonly double MaxDitTime = 0.3d;
	public static readonly double MaxDahTime = MaxDitTime * 3;

	private static bool justReleased = false;
	public static bool KeyDownRn { get; private set; }

	private static double keyDownTimestamp;
	public static double HoldTime => (KeyDownRn || justReleased) ? Raylib.GetTime() - keyDownTimestamp : 0f;


	public static void Update()
	{
		justReleased = false;

		// Check for if we are starting a hold
		if (Raylib.IsKeyPressed(KeyboardKey.Space))
		{
			KeyDownRn = true;

			// reest/start the timer
			keyDownTimestamp = Raylib.GetTime();
		}

		// Check for if we are ending a hold
		if (Raylib.IsKeyReleased(KeyboardKey.Space))
		{
			KeyDownRn = false;
			justReleased = true;
		}
	}

	// Check for if we have just finished doing something (keyPressed)
	public static bool FinishedDit => justReleased && (HoldTime <= MaxDitTime);
	public static bool FinishedDah => justReleased && ((HoldTime > MaxDitTime) && (HoldTime <= MaxDahTime));

	// Check for if we are currently doing something (keyDown)
	public static bool DoingDit => KeyDownRn && HoldTime <= MaxDitTime;
	public static bool DoingDah => KeyDownRn && (HoldTime > MaxDitTime) && (HoldTime <= MaxDahTime);
}