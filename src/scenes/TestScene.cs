using Raylib_cs;

class TestScene : Scene
{
	private int debugCount = 0;

	public override void Start()
	{
		UiHandler.AddElement(new Button("test 1"));
		UiHandler.AddElement(new Button("test 2"));
		UiHandler.AddElement(new Button("test 3"));
	}

	public override void Render()
	{
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
	}
}