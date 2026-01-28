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

		Training.Start();

		UiHandler.AddElement(new Button("test 1"));
		UiHandler.AddElement(new Button("test 2"));
		UiHandler.AddElement(new Button("test 3"));

		int debugCount = 0;

		while (!Raylib.WindowShouldClose())
		{
			Input.Update();
			UiHandler.Update(); 

			Raylib.BeginDrawing();
			TextDrawer.BeginDrawing();
			Raylib.ClearBackground(Color.Black);

			// Training.Render();

			UiHandler.Render();

			TextDrawer.DrawLine($"max dit: {Input.MaxDitTime:0.###}s");
			TextDrawer.DrawLine($"max dah: {Input.MaxDahTime:0.###}s");
			TextDrawer.DrawGap();

			Color color = Input.HoldTime > Input.MaxDitTime ? Color.Beige : Color.Gold;
			if (Input.HoldTime > Input.MaxDahTime) color = Color.Red;
			TextDrawer.DrawLine($"{Input.HoldTime:0.000}s", color);

			string status = "";
			if (Input.DoingDit) status = "dit";
			else if (Input.DoingDah) status = "dah";
			TextDrawer.DrawLine(status);

			if (Input.FinishedDit) debugCount++;
			TextDrawer.DrawGap();
			TextDrawer.DrawLine(debugCount);

			// if (Input.FinishedDit) Console.WriteLine("dit");
			// if (Input.FinishedDah) Console.WriteLine("dah");

			Raylib.EndDrawing();
		}

		continuousWave.Unload();

		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();
	}
}
