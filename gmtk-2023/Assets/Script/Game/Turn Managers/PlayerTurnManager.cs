using System;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    [SerializeField] EntitySpawner playerSpawner;

    public event Action<GameState> OnTurnEnded;

    public GameState BeginTurn()
    {
        if (!playerSpawner.HasLivingEntities())
            return GameState.Won;

        ApplyStatusEffects();

        if (!playerSpawner.HasLivingEntities())
            return GameState.Won;

        Attack();

        return GameState.MobTurn;
    }

    private void ApplyStatusEffects()
    {

    }

    private void Attack()
    {

    }
}
