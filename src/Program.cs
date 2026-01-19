using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Raylib.InitWindow(854, 480, "Far away drawings");
		Raylib.InitAudioDevice();

		ContinuousWave continuousWave = new ContinuousWave(440);

		while (!Raylib.WindowShouldClose())
		{
			if (Raylib.IsKeyDown(KeyboardKey.Space)) continuousWave.PlayContinuously();

			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			Raylib.DrawText("morsing the code rn", 10, 10, 30, Color.White);
			Raylib.EndDrawing();
		}

		continuousWave.Unload();

		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();
	}
}
