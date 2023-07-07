using UnityEngine;

public class EntityPlacer : MonoBehaviour
{
    [SerializeField] private EntitySlots mobSlots;
    [SerializeField] private EntitySlots playerSlots;

    void Update()
    {
        
    }

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
        switch (entity.GetStats().GetEntityType())
        {
            case EntityType.Mob:
                mobSlots.PlaceEntity(entity);
                break;
            case EntityType.Player:
                playerSlots.PlaceEntity(entity);
                break;
        }
    }
}
