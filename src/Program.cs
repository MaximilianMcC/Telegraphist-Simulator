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

		Training.Start();

		while (!Raylib.WindowShouldClose())
		{
			// if (Raylib.IsKeyDown(KeyboardKey.Space)) continuousWave.PlayContinuously();

			// if (Raylib.IsKeyPressed(KeyboardKey.S)) MorseCodePlayer.Send("sos", wpm);
			Training.Update();
			MorseCodePlayer.Update();

			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			Training.Render();
			Raylib.EndDrawing();
		}

		continuousWave.Unload();

		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();
	}
}
