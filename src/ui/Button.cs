using System.Numerics;
using Raylib_cs;

class Button : UiElement
{
	public string Text { get; set; }
	private Rectangle shape;

	public Vector2 Size => new Vector2(130, 40);

	public Button(string text)
	{
		// Our index is just our position in the list
		//? saving the index might be useless ngl if we just use the list
		UiHandler.Elements.Add(this);
		Index = UiHandler.Elements.Count - 1;

		// If we're the only element then select ourself
		if (UiHandler.Elements.Count == 1) Selected = true;

		Text = text;

		// TODO: fix this
		const float elementMargin = 10f;
		shape = new Rectangle(
			new Vector2(
				elementMargin,
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