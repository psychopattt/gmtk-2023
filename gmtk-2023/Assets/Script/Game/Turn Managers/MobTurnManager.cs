using System;
using TMPro;
using UnityEngine;

public class MobTurnManager : MonoBehaviour
{
    [SerializeField] private int availableMobCount = 50;
    [SerializeField] private MenuLogic menuLogic;
    [SerializeField] private EntitySpawner mobSpawner;
    [SerializeField] private EntitySpawner playerSpawner;
    [SerializeField] private TMP_Text mobDeathCount;
    private int turnNumber = 0;

    public event Action OnEntityTurnEnded;
    public event Action<GameState> OnGameTurnEnded;

    private void Awake()
    {
        mobDeathCount.text = string.Format("{0} Remaining Mobs", availableMobCount);
    }

    public void NextTurn()
    {
        if (!mobSpawner.HasLivingEntities())
            mobSpawner.SpawnEntities();

        mobDeathCount.text = string.Format("{0} Remaining Mobs", availableMobCount - mobSpawner.GetDeathCount());
        mobSpawner.MaxEntityAmount = Math.Min(mobSpawner.MaxEntityAmount, availableMobCount);

        SetCurrentMobHint();
        ApplyStatusEffects();
        ActivateUserButtons();
    }

    public void SetCurrentMobHint()
    {
        mobSpawner.SetCurrentMobHint(turnNumber);
    }

    private void ApplyStatusEffects()
    {
        if (mobSpawner.HasLivingEntities() && mobSpawner.GetDeathCount() < availableMobCount)
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

        if (mobSpawner.GetDeathCount() >= availableMobCount)
        {
            OnGameTurnEnded?.Invoke(GameState.Lost);
            turnNumber = 0;
        }
        else if (turnNumber >= mobSpawner.EntityCount)
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
