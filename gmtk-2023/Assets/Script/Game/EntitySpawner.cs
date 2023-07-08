using System;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private int minEntityAmount = 1;
    [SerializeField] private int maxEntityAmount = 5;

    [SerializeField] private EntityPlacer entityPlacer;

    [SerializeField] private List<GameObject> entityPrefabs;
    private List<GameObject> currentEntityPrefabs;
    private List<Entity> currentEntities;

    public event Action OnAllEntitiesDead;

    private void Awake()
    {
        currentEntities = new List<Entity>();
        currentEntityPrefabs = new List<GameObject>();
    }

    public bool HasLivingEntities() => currentEntities.Count > 0;

    public int EntityCount => currentEntities.Count;

    public void SpawnEntities()
    {
        for (int i = 0; i < UnityEngine.Random.Range(minEntityAmount, maxEntityAmount); i++)
        {
            int selectedEntityIndex = UnityEngine.Random.Range(0, entityPrefabs.Count);
            GameObject selectedEntityInstance = Instantiate(entityPrefabs[selectedEntityIndex]);
            Entity selectedEntity = selectedEntityInstance.GetComponent<Entity>();
            currentEntityPrefabs.Add(selectedEntityInstance);
            currentEntities.Add(selectedEntity);

            entityPlacer.PlaceEntity(selectedEntity);
            AddEventListeners(selectedEntity);
        }
    }

    public Entity GetEntity(int entityIndex)
    {
        Debug.Log(entityIndex);
        return currentEntities[entityIndex];
    }

    public List<Entity> GetEntities()
    {
        return currentEntities;
    }

    private void AddEventListeners(Entity entity)
    {
        entity.OnDeath += delegate { HandleEntityDeath(entity); };
    }

    private void HandleEntityDeath(Entity entity)
    {
        int entityIndex = currentEntities.IndexOf(entity);
        currentEntities.RemoveAt(entityIndex);

        Destroy(currentEntityPrefabs[entityIndex]);
        currentEntityPrefabs.RemoveAt(entityIndex);

        if (currentEntities.Count == 0)
            OnAllEntitiesDead?.Invoke();
    }
}
