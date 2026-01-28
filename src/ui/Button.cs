using System.Numerics;
using Raylib_cs;

class Button : UiElement
{
	public string Text { get; set; }
	private Rectangle shape;

	public Vector2 Size => new Vector2(130, 40);

	public Button(string text)
	{
		Index = UiHandler.Elements.Count;

		Text = text;

		// TODO: fix this
		const float elementMargin = 10f;
		shape = new Rectangle(
			new Vector2(
				elementMargin + 300,
		        Index * (Size.Y + elementMargin) + elementMargin
			),
			Size
		);
	}

	public override void Draw()
	{
		float thickness = Selected ? 4f : 1f;

		// Draw the outline
		Raylib.DrawRectangleLinesEx(shape, thickness, Color.White);

		// Draw the text
		Raylib.DrawText(Text, (int)shape.X, (int)shape.Y, 30, Color.White);
	}
}