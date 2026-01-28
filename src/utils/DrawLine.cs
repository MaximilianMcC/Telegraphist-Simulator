using Raylib_cs;

static class TextDrawer
{
	public static float Padding { get; set; } = 10f;

	private static float y;
	public static void BeginDrawing() => y = 0;

	public static void DrawLine(string text) => DrawLine(text, 30, Color.White);
	public static void DrawLine(string text, int fontSize) => DrawLine(text, fontSize, Color.White);
	public static void DrawLine(string text, int fontSize, Color color)
	{
		Raylib.DrawText(text, (int)Padding, (int)(Padding + y), fontSize, color);
		y += fontSize + Padding;
	}
}