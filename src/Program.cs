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

		UiHandler.Elements.Add(new Button("test 1"));
		UiHandler.Elements.Add(new Button("test 2"));
		UiHandler.Elements.Add(new Button("test 3"));

		int counter = 0;


		while (!Raylib.WindowShouldClose())
		{
			Input.Update();
			UiHandler.Update();

			// if (Input.KeyDown) continuousWave.PlayContinuously();

			// if (Input.Dit) counter++;
			// Console.WriteLine(counter);

			// if (Raylib.IsKeyPressed(KeyboardKey.S)) MorseCodePlayer.Send("sos", wpm);
			// Training.Update();
			MorseCodePlayer.Update();


			// string lastThingDid = "";
			// if (Input.DoingDit) lastThingDid = "Dit";
			// else if (Input.DoingDah) lastThingDid = "Dah";


			Raylib.BeginDrawing();
			TextDrawer.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			// Training.Render();
			// UiHandler.Render();

			TextDrawer.DrawLine($"max dit: {Input.MaxDitTime:0.###}s");
			TextDrawer.DrawLine($"max dah: {Input.MaxDahTime:0.###}s");
			TextDrawer.DrawGap();
			TextDrawer.DrawLine($"{Input.HoldTime:0.000}s");

			if (Input.FinishedDit) Console.WriteLine("dit");
			if (Input.FinishedDah) Console.WriteLine("dah");

			// Raylib.DrawText($"{Input.KeyDown}\ni: {counter}\n{lastThingDid}", 10, 400, 20, Color.White);
			Raylib.EndDrawing();
		}

		continuousWave.Unload();

		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();
	}
}
