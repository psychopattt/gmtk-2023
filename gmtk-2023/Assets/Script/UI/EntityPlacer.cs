using System.Collections.Generic;
using UnityEngine;

public class EntityPlacer : MonoBehaviour
{
    [SerializeField] private EntitySlots mobSlots;
    [SerializeField] private EntitySlots playerSlots;

    public bool HasAvailableSlots(EntityType slotType)
    {
        return slotType switch {
            EntityType.Mob => mobSlots.HasAvailableSlots(),
            EntityType.Player => playerSlots.HasAvailableSlots(),
            _ => false,
        };
    }

    public void PlaceEntity(Entity entity)
    {
        switch (entity.Stats.Type)
        {
            case EntityType.Mob:
                mobSlots.PlaceEntity(entity);
                break;
            case EntityType.Player:
                playerSlots.PlaceEntity(entity);
                break;
        }
    }

    public void PlaceEntities(IEnumerable<Entity> entities)
    {
        foreach (Entity entity in entities)
            PlaceEntity(entity);
    }

    public void RemoveEntity(Entity entity)
    {
        switch (entity.Stats.Type)
        {
            case EntityType.Mob:
                mobSlots.RemoveEntity(entity);
                break;
            case EntityType.Player:
                playerSlots.RemoveEntity(entity);
                break;
        }
    }

    public void RemoveEntities(IEnumerable<Entity> entities)
    {
        foreach (Entity entity in entities)
            RemoveEntity(entity);
    }

    public void RemoveAllEntities(EntityType type)
    {
        switch (type)
        {
            case EntityType.Mob:
                mobSlots.RemoveAllEntities();
                break;
            case EntityType.Player:
                playerSlots.RemoveAllEntities();
                break;
        }
    }

    public void RemoveAllEntities()
    {
        RemoveAllEntities(EntityType.Player);
        RemoveAllEntities(EntityType.Mob);
    }
}
