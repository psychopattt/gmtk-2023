using UnityEngine;

public class GameTurnManager : MonoBehaviour
{
    private int turnNumber = 0;
    private GameState gameState;
    private MobTurnManager mobTurnManager;
    private PlayerTurnManager playerTurnManager;

    private void Awake()
    {
        playerTurnManager = GetComponent<PlayerTurnManager>();
        mobTurnManager = GetComponent<MobTurnManager>();
        playerTurnManager.OnTurnEnded += HandleTurnEnd;
        mobTurnManager.OnTurnEnded += HandleTurnEnd;
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
                playerTurnManager.BeginTurn();
                break;
            case GameState.MobTurn:
                mobTurnManager.BeginTurn();
                break;
            case GameState.Won:
                // TODO call some class that handles victory/loss screen
                break;
            case GameState.Lost:
                // TODO call some class that handles victory/loss screen
                break;
        }

        turnNumber++;
    }

    private void InitializeGame()
    {
        gameState = GameState.PlayerTurn;
        NextTurn();
    }

    private void HandleTurnEnd(GameState nextGameState)
    {
        gameState = nextGameState;
        NextTurn();
    }
}
