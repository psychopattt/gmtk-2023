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

    private void Start()
    {
        playerSpawner.OnEntitiesSpawned += NextTurn;
    }

    public void NextTurn()
    {
        if (!initialized)
        {
            initialized = true;
            StartCoroutine(playerSpawner.SpawnEntities());
        }
        else
        {
            StartCoroutine(ExecuteTurn());
        }
    }

    private IEnumerator ExecuteTurn()
    {
        yield return ApplyStatusEffects();
        yield return Attack();

        yield return EndTurnStatusEffects();
        turnNumber++;

        if (HasLost())
        {
            OnGameTurnEnded?.Invoke(GameState.Won);
        }
        else if (turnNumber >= playerSpawner.EntityCount)
        {
            turnNumber = 0;
            OnGameTurnEnded?.Invoke(GameState.MobTurn);
        }
        else
        {
            OnEntityTurnEnded?.Invoke();
        }

        yield return new WaitForSeconds(0.5f);
    }

    private bool HasLost()
    {
        return !playerSpawner.HasLivingEntities();
    }

    private IEnumerator EndTurnStatusEffects()
    {
        if (!HasLost())
        {
            yield return new WaitForSeconds(0.3f);
            Entity currentEntity = playerSpawner.GetEntity(turnNumber);
            currentEntity.ApplyBleed();
            
        }
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator ApplyStatusEffects()
    {
        if (!HasLost())
        {
            yield return new WaitForSeconds(0.3f);

            Entity currentEntity = playerSpawner.GetEntity(turnNumber);
            currentEntity.ApplyStartTurnEffect();
        }

        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator Attack()
    {
        if (!HasLost())
        {
            yield return new WaitForSeconds(0.3f);

            Entity currentEntity = playerSpawner.GetEntity(turnNumber);
            Attack selectedAttack = currentEntity.Stats.Attacks[UnityEngine.Random.Range(0, currentEntity.Stats.Attacks.Count)];
            Entity[] possibleTargets = mobSpawner.GetEntities().ToArray();

            currentEntity.Attack(possibleTargets, selectedAttack);
        }

        yield return new WaitForSeconds(0.5f);
    }
}
