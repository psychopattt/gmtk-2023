using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    private const string gamePath = "Scenes/GameScene";
    private const string menuScenePath = "Scenes/MainMenu";
    private const string gameOverWinPath = "Scenes/GameOverWin";
    private const string gameOverLossPath = "Scenes/GameOverLoss";

    private static readonly SceneController sceneControllerSingleton = new SceneController();

    public static SceneController Instance => sceneControllerSingleton;

    public void LoadGame()
    {
        SceneManager.LoadScene(gamePath, LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuScenePath, LoadSceneMode.Single);
    }

    public void LoadGameOverWin()
    {
        SceneManager.LoadScene(gameOverWinPath, LoadSceneMode.Single);
    }

    public void LoadGameOverLoss()
    {
        SceneManager.LoadScene(gameOverLossPath, LoadSceneMode.Single);
    }
}
