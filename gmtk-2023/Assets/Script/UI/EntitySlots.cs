using UnityEngine;

public class EntitySlots : MonoBehaviour
{
    private EntitySlot[] slots;

    void Start()
    {
        slots = transform.GetComponentsInChildren<EntitySlot>();
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
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsAvailble())
                slots[i].SetEntity(entity);
        }
    }

    public void RemoveEntity(Entity entity)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetEntity() == entity)
                slots[i].Clear();
        }
    }
}
