using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private SceneController sceneController;

    private void Awake()
    {
        sceneController = SceneController.Instance;
    }

    public void LoadGame() => sceneController.LoadGame();

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
