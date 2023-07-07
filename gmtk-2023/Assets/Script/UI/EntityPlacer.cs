using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlacer : MonoBehaviour
{
    [SerializeField] private EntitySlots mobSlots;
    [SerializeField] private EntitySlots playerSlots;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool HasAvailableSlots(SlotType slotType)
    {
        switch (slotType)
        {
            case SlotType.Mob:
                return mobSlots.HasAvailableSlots();
            case SlotType.Player:
                return playerSlots.HasAvailableSlots();
        }

        return false;
    }

    public void PlaceEntity(SlotType slotType, Entity entity)
    {
        switch (slotType)
        {
            case SlotType.Mob:
                mobSlots.PlaceEntity(entity);
                break;
            case SlotType.Player:
                playerSlots.PlaceEntity(entity);
                break;
        }
    }
}
