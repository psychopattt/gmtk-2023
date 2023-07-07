using UnityEngine;

public class EntitySlot : MonoBehaviour
{
    private Entity currentEntity;

    public bool IsAvailble()
    {
        return currentEntity != null;
    }
}
