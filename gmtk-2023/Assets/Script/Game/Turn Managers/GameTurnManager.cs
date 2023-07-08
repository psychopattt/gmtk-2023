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
                mobTurnManager.NextTurn();
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

    private void HandleEntityTurnEnd(GameState nextGameState)
    {
        gameState = nextGameState;
        NextTurn();
    }
}
