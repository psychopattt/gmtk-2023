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

    /// <summary>
    /// Places the entity in the first available slot and returns the slot index
    /// Returns -1 if the entity could not be placed in any slot
    /// </summary>
    public int PlaceEntity(Entity entity)
    {
        switch (entity.Stats.Type)
        {
            case EntityType.Mob:
                return mobSlots.PlaceEntity(entity);
            case EntityType.Player:
                return playerSlots.PlaceEntity(entity);
        }

        return -1;
    }

    public void PlaceEntities(IEnumerable<Entity> entities)
    {
        foreach (Entity entity in entities)
            PlaceEntity(entity);
    }

    /// <summary>
    /// Returns the slot index of the entity
    /// Returns -1 if the entity is not in any slot
    /// </summary>
    public int GetEntitySlot(Entity entity)
    {
        switch (entity.Stats.Type)
        {
            case EntityType.Mob:
                mobSlots.GetEntitySlot(entity);
                break;
            case EntityType.Player:
                playerSlots.GetEntitySlot(entity);
                break;
        }

        return -1;
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

    public void RemoveEntity(EntityType type, int slotIndex)
    {
        switch (type)
        {
            case EntityType.Mob:
                mobSlots.RemoveEntity(slotIndex);
                break;
            case EntityType.Player:
                playerSlots.RemoveEntity(slotIndex);
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
        mobSlots.RemoveAllEntities();
        playerSlots.RemoveAllEntities();
    }
}
