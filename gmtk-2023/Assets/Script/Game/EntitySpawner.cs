using System;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private int minEntityAmount = 1;
    [SerializeField] private int maxEntityAmount = 5;

    [SerializeField] private EntityPlacer entityPlacer;

    [SerializeField] private List<Entity> entityVariants;
    private List<Entity> currentEntities;

    public event Action OnAllEntitiesDead;

    private void Awake()
    {
        currentEntities = new List<Entity>();
    }

    public bool HasLivingEntities() => currentEntities.Count > 0;

    public int EntityCount => currentEntities.Count;

    public void SpawnEntities()
    {
        for (int i = 0; i < UnityEngine.Random.Range(minEntityAmount, maxEntityAmount); i++)
        {
            int randomEntityIndex = UnityEngine.Random.Range(0, entityVariants.Count);
            Entity selectedEntity = entityVariants[randomEntityIndex];
            currentEntities.Add(selectedEntity);

            entityPlacer.PlaceEntity(selectedEntity);
            AddEventListeners(selectedEntity);
        }
    }

    public Entity GetEntity(int entityIndex)
    {
        return currentEntities[entityIndex];
    }

    private void AddEventListeners(Entity entity)
    {
        entity.OnDeath += delegate { HandleEntityDeath(entity); };
    }

    private void HandleEntityDeath(Entity entity)
    {
        currentEntities.Remove(entity);

        if (currentEntities.Count == 0)
            OnAllEntitiesDead?.Invoke();
    }
}
