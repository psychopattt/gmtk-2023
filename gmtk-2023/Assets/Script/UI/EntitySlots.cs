using UnityEngine;

public class EntitySlots : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;

    private const int slotCount = 10;
    private EntitySlot[] slots = new EntitySlot[slotCount];

    private void Awake()
    {
        Vector3 offset = new Vector3();

        for (int i = 0; i < slotCount; i++)
        {
            offset.x = Random.Range(-100, 100);
            offset.y += 50;
            offset.z += 10;

            slots[i] = Instantiate(slotPrefab, transform).GetComponent<EntitySlot>();
            slots[i].transform.position += offset;
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

    public void PlaceEntity(Entity entity)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsAvailable())
            {
                slots[i].SetEntity(entity);
                break;
            }
        }
    }

    public void RemoveEntity(Entity entity)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetEntity() == entity)
            {
                slots[i].Clear();
                break;
            }
        }
    }

    public void RemoveAllEntities()
    {
        foreach (EntitySlot entitySlot in slots)
            entitySlot.Clear();
    }
}
