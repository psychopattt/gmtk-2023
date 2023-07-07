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
    private Transform mainCanvas;


    [SerializeField]
    private List<GameObject> players;
    [SerializeField]
    private List<GameObject> ennemy;

    [SerializeField]
    private int turnNumber = 0;



    void Start()
    {
        gameState = GameState.Start;
        //SpawnEverything
        SpawnMob(true);
        SpawnMob(false);

        gameState = GameState.PlayerTurn;
        foreach(GameObject entity in players)
        {
            //entity.playturn
            turnNumber++;
        }
        gameState = GameState.EnnemyTurn;
        foreach(GameObject entity in ennemy)
        {
            //entity.playTurn
            turnNumber++;
        }
    }

    void SpawnMob(bool isPlayerTeam)
    {
        GameObject newMob = Instantiate(pfCharacter);
        if (isPlayerTeam)
        {
            ennemy.Add(newMob);
        }
        else
        {
            players.Add(newMob);
        }
        
    }

    public void incrementTurnNumber()
    {
        turnNumber++;
    }

    public void OnChangeTurn()
    {

    }
}
