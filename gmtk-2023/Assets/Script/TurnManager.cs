using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private List<Entity> enemyEntity;

    [SerializeField]
    private Entity playerEntity;

    [SerializeField]
    private Transform mainCanvas;


    [SerializeField]
    private List<Entity> players;

    [SerializeField]
    private List<Entity> enemy;

    [SerializeField]
    private int turnNumber = 0;



    void Start()
    {
        gameState = GameState.Start;
        StartCoroutine(SetUpBattle());
        
        PlayTurn();
    }
    IEnumerator SetUpBattle()
    {

        entityPlacer.PlaceEntity(playerEntity);
        players.Add(playerEntity);

        for (int i= 0; i < 4; i++)
        {
            
            int randomEnnemy = Random.Range(0, enemyEntity.Count());
            entityPlacer.PlaceEntity(enemyEntity[randomEnnemy]);
        }

        yield return new WaitForSeconds(2f);

        gameState = GameState.PlayerTurn;
        PlayerTurn();
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
        foreach (Entity entity in players)
        {

            //entity.playturn
            turnNumber++;
        }
        gameState = GameState.EnnemyTurn;
        foreach (Entity entity in enemy)
        {
            //entity.playTurn
            turnNumber++;
        }
    }
    private void PlayerTurn()
    {

    }
    public void gameStateChanged(GameState oldValue, GameState newValue)
    {
        Debug.Log("GameState has changed");
    }
}
