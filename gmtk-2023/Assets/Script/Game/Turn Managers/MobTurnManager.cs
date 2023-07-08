using System;
using System.Collections;
using UnityEngine;

public class MobTurnManager : MonoBehaviour
{
    [SerializeField] EntitySpawner mobSpawner;
    [SerializeField] EntitySpawner playerSpawner;
    private int turnNumber = 0;

    public event Action OnEntityTurnEnded;
    public event Action<GameState> OnGameTurnEnded;

    public void NextTurn()
    {
        if (!mobSpawner.HasLivingEntities())
            mobSpawner.SpawnEntities();

        StartCoroutine(ApplyStatusEffects());
        ActivateUserButtons();
    }

    private IEnumerator ApplyStatusEffects()
    {
        Entity currentEntity = playerSpawner.GetEntity(turnNumber);
        // TODO currentEntity.ApplyStartTurnEffects();

        yield return new WaitForSeconds(2);
    }

    public void ActivateUserButtons()
    {
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
