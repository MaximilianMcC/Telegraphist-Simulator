using System.Numerics;
using Raylib_cs;

static partial class Utils
{
	public static void DrawCentreText(string text, float fontSize)
	{
		Vector2 size = Raylib.MeasureTextEx(Raylib.GetFontDefault(), text, fontSize, fontSize / 10);

		Raylib.DrawTextPro(
			Raylib.GetFontDefault(),
			text,
			Raylib.GetScreenCenter(),
			size * 0.5f,
			0f,
			fontSize,
			fontSize / 10,
			Color.White
		);
	}
}