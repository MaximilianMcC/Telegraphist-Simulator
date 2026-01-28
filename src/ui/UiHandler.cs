abstract class UiElement
{
	public int Index { get; protected set; } 
	public bool Selected { get; set; }

	public virtual void Update() { }
	public virtual void Draw() { }
	public virtual void CleanUp() { }
}

static class UiHandler
{
	public static List<UiElement> Elements = [];
	private static int currentElementIndex = 0;

	public static void AddElement(UiElement element)
	{
		Elements.Add(element);

		// If this is the first element then select it
		if (Elements.Count == 1) element.Selected = true;
	}

	public static void Update()
	{
		// Move onto the next element
		// TODO: i (..) to move to previous element maybe
		if (Input.FinishedDit)
		{
			// Check for if we even have any elements to switch to
			if (Elements.Count <= 1) return;

			// Loop back around to 0 if we reach the end
			// TODO: Might need to -1 from the count
			int previousElementIndex = currentElementIndex;
			currentElementIndex = (currentElementIndex + 1) % Elements.Count;

			// Unselect the old element and select the new one instead
			Elements[previousElementIndex].Selected = false;
			Elements[currentElementIndex].Selected = true;
		}
	}

	public static void Render()
	{
		foreach (UiElement element in Elements)
		{
			element.Draw();
		}
	}
}