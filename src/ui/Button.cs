using System.Numerics;
using Raylib_cs;

class Button : UiElement
{
	public string Text { get; set; }

	private Rectangle shape;

	public Button(string text)
	{
		Index = UiHandler.Elements.Count;

		Text = text;

		const float elementMargin = 10f;
		Vector2 size = new Vector2(130, 40);

		shape = new Rectangle(
			new Vector2(
				elementMargin + 300,
		        Index * (size.Y + elementMargin) + elementMargin
			),
			size
		);
	}

	public override void Update()
	{
		// Ensure we are selected
		if (Selected == false) return;

		// If we've done a dah then the button has been pressed
		if (Input.FinishedDah)
		{
			Text = "clicked";
		}
	}

	public override void Draw()
	{
		// If we're 'being' clicked then draw the progress
		if (Selected)
		{
			float progress = (float)Math.Min(Input.HoldTime / Input.MaxDahTime, 1f);
			Raylib.DrawRectangleV(
				shape.Position,
				shape.Size * new Vector2(progress, 1),
				Color.Orange
			);
		}

		// Draw the outline
		float thickness = Selected ? 4f : 1f;
		Raylib.DrawRectangleLinesEx(shape, thickness, Color.White);

		// Draw the text
		Raylib.DrawText(Text, (int)shape.X, (int)shape.Y, 30, Color.White);
	}
}