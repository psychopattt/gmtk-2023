using System;
using UnityEngine;

public class MobTurnManager : MonoBehaviour
{
    [SerializeField] private MenuLogic menuLogic;
    [SerializeField] private EntitySpawner mobSpawner;
    [SerializeField] private EntitySpawner playerSpawner;
    private int turnNumber = 0;

    public event Action OnEntityTurnEnded;
    public event Action<GameState> OnGameTurnEnded;

    public void NextTurn()
    {
        if (!mobSpawner.HasLivingEntities())
            mobSpawner.SpawnEntities();

        ApplyStatusEffects();
        ActivateUserButtons();
    }

    private void ApplyStatusEffects()
    {
        if (mobSpawner.HasLivingEntities())
        {
            Entity currentEntity = mobSpawner.GetEntity(turnNumber);
            currentEntity.ApplyStartTurnEffect();
        }
        else
        {
            EndTurn();
        }
    }

    public void ActivateUserButtons()
    {
        if (mobSpawner.HasLivingEntities())
        {
            menuLogic.SetMenu(mobSpawner.GetEntity(turnNumber));
            // TODO activate UI controls for the mob currently playing
        }
        else
        {
            EndTurn();
        }
    }

    public void Attack(Attack attack)
    {
        // TODO called by the user when using an attack button in the UI
        mobSpawner.GetEntity(turnNumber).Attack(playerSpawner.GetEntities().ToArray(), attack);
        EndTurn();
    }

    private void EndTurn()
    {
        turnNumber++;

        if (turnNumber >= mobSpawner.EntityCount)
        {
            OnGameTurnEnded?.Invoke(GameState.PlayerTurn);
            turnNumber = 0;
        }
        else
        {
            OnEntityTurnEnded?.Invoke();
            NextTurn();
        }
    }
}
