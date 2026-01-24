using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Raylib.InitWindow(854, 480, "Far away drawings");
		Raylib.InitAudioDevice();

		WpmTimings wpm = new WpmTimings(10);

		ContinuousWave continuousWave = new ContinuousWave();
		continuousWave.Effects.Add(new SawtoothWave(0.3d));
		continuousWave.Effects.Add(new SineWave(0.9d));

		MorseCodePlayer.ContinuousWave = continuousWave;

		Training.Start();

		while (!Raylib.WindowShouldClose())
		{
			if (Raylib.IsKeyDown(KeyboardKey.Space)) continuousWave.PlayContinuously();

			// if (Raylib.IsKeyPressed(KeyboardKey.S)) MorseCodePlayer.Send("sos", wpm);
			// Training.Update();
			MorseCodePlayer.Update();

			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			// Training.Render();
			// Raylib.DrawText($"{Input.KeyDown}", 10, 10, 30, Color.White);
			Raylib.EndDrawing();
		}

		continuousWave.Unload();

		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();
	}
}
