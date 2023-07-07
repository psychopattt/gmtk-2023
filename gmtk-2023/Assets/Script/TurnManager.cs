using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private Transform pfCharacter;

    [SerializeField]
    private Transform mainCanvas;

    void Start()
    {
        gameState = GameState.Start;
        
        SpawnMob(true);
        SpawnMob(false);
    }

    void SpawnMob(bool isPlayerTeam)
    {
        Vector3 position;
        if (isPlayerTeam)
        {
            position = new Vector3(-50, 0);
        }
        else
        {
            position = new Vector3(50, 0);
        }
        Transform newMob = Instantiate(pfCharacter, position, Quaternion.identity);
        newMob.SetParent(mainCanvas);
    }
}
