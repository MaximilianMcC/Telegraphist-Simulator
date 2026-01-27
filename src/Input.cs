using Raylib_cs;

class Input
{
	private static double keyDownTimestamp;
	private static double timeKeyWasDownFor;
	public static bool KeyDown => keyDownTimestamp != 0;

	public static void Update()
	{
		// Check for if we're starting a send
		if (Raylib.IsKeyPressed(KeyboardKey.Space))
		{
			keyDownTimestamp = Raylib.GetTime();
		}

		// Check for if we're ending a send
		if (Raylib.IsKeyReleased(KeyboardKey.Space))
		{
			timeKeyWasDownFor = Raylib.GetTime() - keyDownTimestamp;
			keyDownTimestamp = 0;
		}
	}

	public static bool Dit()
	{
		if (timeKeyWasDownFor > 0 && timeKeyWasDownFor <= 1)
		{
			timeKeyWasDownFor = 0;
			return true;
		}

		return false;
	}

	public static bool Dah()
	{
		if (timeKeyWasDownFor > 1)
		{
			timeKeyWasDownFor = 0;
			return true;
		}

		return false;
	}
}