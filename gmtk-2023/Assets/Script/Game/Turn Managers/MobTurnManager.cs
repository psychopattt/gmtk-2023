using System;
using UnityEngine;

public class MobTurnManager : MonoBehaviour
{
    [SerializeField] EntitySpawner mobSpawner;

    public event Action<GameState> OnTurnEnded;

    public GameState BeginTurn()
    {
        if (!mobSpawner.HasLivingEntities())
            return GameState.Lost;

        return GameState.PlayerTurn;
    }
}
