using System;
using System.Collections;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    [SerializeField] EntitySpawner mobSpawner;
    [SerializeField] EntitySpawner playerSpawner;
    private bool initialized = false;
    private int turnNumber = 0;

    public event Action OnEntityTurnEnded;
    public event Action<GameState> OnGameTurnEnded;

    private void Initialize()
    {
        if (!initialized)
        {
            initialized = true;
            playerSpawner.SpawnEntities();
        }
    }

    public void NextTurn()
    {
        Initialize();
        StartCoroutine(ApplyStatusEffects());
        StartCoroutine(Attack());

        turnNumber++;

        if (HasLost())
        {
            OnGameTurnEnded?.Invoke(GameState.Won);
        }
        else if (turnNumber == playerSpawner.EntityCount)
        {
            turnNumber = 0;
            OnGameTurnEnded?.Invoke(GameState.MobTurn);
        }
        else
        {
            OnEntityTurnEnded?.Invoke();
        }
    }

    private bool HasLost()
    {
        return !playerSpawner.HasLivingEntities();
    }

    private IEnumerator ApplyStatusEffects()
    {
        if (!HasLost())
        {
            Entity currentEntity = playerSpawner.GetEntity(turnNumber);
            // TODO currentEntity.ApplyStartTurnEffects();
        }

        yield return new WaitForSeconds(2);
    }

    private IEnumerator Attack()
    {
        if (!HasLost())
        {
            Entity currentEntity = playerSpawner.GetEntity(turnNumber);
            Attack selectedAttack = currentEntity.Stats.Attacks[UnityEngine.Random.Range(0, currentEntity.Stats.Attacks.Count)];
            Entity[] possibleTargets = new Entity[selectedAttack.TargetAmount];

            //TODO currentEntity.DoAttack(possibleTargets, selectedAttack);

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(2);
    }
}
