using UnityEngine;

public class EntitySlots : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;

    private const int slotCount = 10;
    private readonly EntitySlot[] slots = new EntitySlot[slotCount];

    private void Awake()
    {
        Vector3 offset = new Vector3(0, 0, 100);
        Vector3 position = new Vector3(515, -400, 0);

        for (int i = 0; i < slotCount; i++)
        {
            offset.y += 95;
            offset.z += 10;

            slots[i] = Instantiate(slotPrefab, transform).GetComponent<EntitySlot>();
            slots[i].SetPosition(position + offset);
        }
    }

    public void SetCurrentMobHint(Entity currentMob)
    {
        foreach (EntitySlot slot in slots)
        {
            if (slot.GetEntity() == currentMob)
                slot.SetMobHint();
            else
                slot.ResetMobHint();
        }
    }

    public bool HasAvailableSlots()
    {
        foreach (EntitySlot slot in slots)
        {
            if (slot.IsAvailable())
                return true;
        }

        return false;
    }

    public int PlaceEntity(Entity entity)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsAvailable())
            {
                slots[i].SetEntity(entity);
                return i;
            }
        }

        return -1;
    }

    public int GetEntitySlot(Entity entity)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetEntity() == entity)
                return i;
        }

        return -1;
    }

    public void RemoveEntity(int slotIndex)
    {
        slots[slotIndex].Clear();
    }

    public void RemoveEntity(Entity entity)
    {
        int slotIndex = GetEntitySlot(entity);

        if (slotIndex != -1)
            slots[slotIndex].Clear();
    }

    public void RemoveAllEntities()
    {
        foreach (EntitySlot entitySlot in slots)
            entitySlot.Clear();
    }
}
