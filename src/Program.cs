using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Raylib.InitWindow(854, 480, "Far away drawings");
		Raylib.InitAudioDevice();

		WpmTimings wpm = new WpmTimings(10);
		ContinuousWave continuousWave = new ContinuousWave(440);
		MorseCodePlayer.ContinuousWave = continuousWave;

		Console.WriteLine(wpm);

		while (!Raylib.WindowShouldClose())
		{
			if (Raylib.IsKeyDown(KeyboardKey.Space)) continuousWave.PlayContinuously();

			if (Raylib.IsKeyPressed(KeyboardKey.S)) MorseCodePlayer.Send("sos", wpm);
			MorseCodePlayer.Update();

			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			Raylib.DrawText($"morsing the code rn\n\n\n{MorseCodePlayer.SendingRn}", 10, 10, 30, Color.White);
			Raylib.EndDrawing();
		}

		continuousWave.Unload();

		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();
	}
}
