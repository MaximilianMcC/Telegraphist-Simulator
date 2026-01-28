using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Raylib.InitWindow(854, 480, "Far away drawings");
		Raylib.InitAudioDevice();

		WpmTimings wpm = new WpmTimings(10);

		ContinuousWave continuousWave = new ContinuousWave(800);
		// continuousWave.Effects.Add(new SawtoothWave(0.3d));
		continuousWave.Effects.Add(new SineWave(1d));
		MorseCodePlayer.ContinuousWave = continuousWave;

		SceneManager.SetScene(new TestScene());

		while (!Raylib.WindowShouldClose())
		{
			Input.Update();
			UiHandler.Update(); 
			SceneManager.CurrentScene.Update();

			Raylib.BeginDrawing();
			TextDrawer.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			UiHandler.Render();
			SceneManager.CurrentScene.Render();
			Raylib.EndDrawing();
		}

		SceneManager.CurrentScene.CleanUp();
		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();
	}
}
