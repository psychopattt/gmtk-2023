using UnityEngine;

public class EntitySlot : MonoBehaviour
{
    private Entity entity = null;

    public bool SetEntity(Entity entity) => this.entity = entity;

    public bool GetEntity() => entity;

    public bool IsAvailble() => entity != null;

    public void Clear() => entity = null;
}
