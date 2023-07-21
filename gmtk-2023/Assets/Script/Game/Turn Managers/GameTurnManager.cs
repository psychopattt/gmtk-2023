using UnityEngine;

public class GameTurnManager : MonoBehaviour
{
    private SceneController sceneController;

    private int turnNumber = 0;
    private GameState gameState;
    private MobTurnManager mobTurnManager;
    private PlayerTurnManager playerTurnManager;

    private void Awake()
    {
        sceneController = SceneController.Instance;
        playerTurnManager = GetComponent<PlayerTurnManager>();
        mobTurnManager = GetComponent<MobTurnManager>();
        playerTurnManager.OnGameTurnEnded += HandleEntityTurnEnd;
        mobTurnManager.OnGameTurnEnded += HandleEntityTurnEnd;
    }

    private void Start()
    {
        gameState = GameState.Start;
        NextTurn();
    }

    public void NextTurn()
    {
        switch (gameState)
        {
            case GameState.Start:
                InitializeGame();
                break;
            case GameState.PlayerTurn:
                playerTurnManager.NextTurn();
                break;
            case GameState.MobTurn:
                mobTurnManager.BeginTurns();
                break;
            case GameState.Won:
                sceneController.LoadGameOverWin();
                break;
            case GameState.Lost:
                sceneController.LoadGameOverLoss();
                break;
        }

        turnNumber++;
    }

    private void InitializeGame()
    {
        gameState = GameState.PlayerTurn;
        NextTurn();
    }

    private void HandleEntityTurnEnd(GameState nextGameState)
    {
        gameState = nextGameState;
        NextTurn();
    }
}
