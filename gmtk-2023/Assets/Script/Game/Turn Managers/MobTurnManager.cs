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
        Entity currentEntity = playerSpawner.GetEntity(turnNumber);
        currentEntity.ApplyStartTurnEffect();
    }

    public void ActivateUserButtons()
    {
        menuLogic.SetMenu(playerSpawner.GetEntity(turnNumber));
        // TODO activate UI controls for the mob currently playing
    }

    public void Attack(Attack attack)
    {
        // TODO called by the user when using an attack button in the UI

        EndTurn();
    }

    private void EndTurn()
    {
        turnNumber++;

        if (turnNumber == mobSpawner.EntityCount)
        {
            OnGameTurnEnded?.Invoke(GameState.PlayerTurn);
            turnNumber = 0;
        }
        else
        {
            OnEntityTurnEnded?.Invoke();
        }
    }
}
