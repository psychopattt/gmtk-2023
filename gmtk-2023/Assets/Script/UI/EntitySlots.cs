using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySlots : MonoBehaviour
{
    [SerializeField] private EntitySlot[] slots;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool HasAvailableSlots()
    {
        foreach (EntitySlot slot in slots)
        {
            if (slot.IsAvailble())
                return true;
        }

        return false;
    }

    public void PlaceEntity(Entity entity)
    {

    }

    public void RemoveEntity(Entity entity)
    {

    }
}
