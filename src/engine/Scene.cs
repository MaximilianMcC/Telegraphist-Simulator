static class SceneManager
{
	public static Scene CurrentScene { get; private set; }
	
	public static void SetScene(Scene newScene)
	{
		// Unload the previous scene if there is one
		CurrentScene?.CleanUp();

		// Start the new scene
		CurrentScene = newScene;
		CurrentScene.Start();
	}
}

abstract class Scene
{
	public virtual void Start() { }
	public virtual void Update() { }
	public virtual void Render() { }
	public virtual void CleanUp() { }
}