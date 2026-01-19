using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Raylib.InitWindow(854, 480, "Far away drawings");
		Raylib.InitAudioDevice();

		while (!Raylib.WindowShouldClose())
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			Raylib.DrawText("morsing the code rn", 10, 10, 30, Color.White);
			Raylib.EndDrawing();
		}

		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();
	}
}