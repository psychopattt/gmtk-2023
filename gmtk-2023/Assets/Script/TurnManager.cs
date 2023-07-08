using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private GameObject pfCharacter;

    [SerializeField]
    private EntityPlacer entityPlacer;
    
    [SerializeField]
    private Entity entity;

    [SerializeField]
    private Transform mainCanvas;


    [SerializeField]
    private List<GameObject> players;
    [SerializeField]
    private List<GameObject> enemy;

    [SerializeField]
    private int turnNumber = 0;



    void Start()
    {
        gameState = GameState.Start;
        //SpawnEverything
        SpawnMob(true);
        SpawnMob(false);
        
        PlayTurn();
    }

    void SpawnMob(bool isPlayerTeam)
    {
        //GameObject newMob = Instantiate(pfCharacter);
        entityPlacer.PlaceEntity(entity);
        if (isPlayerTeam)
        {
            //enemy.Add(newMob);
        }
        else
        {
            //players.Add(newMob);
        }
        
    }

    public void incrementTurnNumber()
    {
        turnNumber++;
    }
    
    public void OnChangeTurn()
    {

    }
    public void PlayTurn()
    {
        gameState = GameState.PlayerTurn;
        foreach (GameObject entity in players)
        {
            //entity.playturn
            turnNumber++;
        }
        gameState = GameState.EnnemyTurn;
        foreach (GameObject entity in enemy)
        {
            //entity.playTurn
            turnNumber++;
        }
    }

    public void gameStateChanged(GameState oldValue, GameState newValue)
    {
        Debug.Log("GameState has changed");
    }
}
