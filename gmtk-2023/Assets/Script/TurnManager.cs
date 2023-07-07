using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private Transform pfCharacter;
    void Start()
    {
        gameState = GameState.Start;

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
        Instantiate(pfCharacter, position, Quaternion.identity);
    }
}
