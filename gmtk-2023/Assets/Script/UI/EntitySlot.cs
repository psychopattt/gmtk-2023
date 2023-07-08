using UnityEngine;

public class EntitySlot : MonoBehaviour
{
    private Entity entity = null;

    public bool IsAvailable() => entity != null;

    public Entity GetEntity() => entity;

    public void SetEntity(Entity entity)
    {
        this.entity = entity;
        entity.OnDeath += Clear;
        entity.OnHealthLost += PlayHealthLostAnimation;
        entity.OnHealthGained += PlayHealthGainedAnimation;
        
        PlayEnterAnimation();
    }

    public void Clear()
    {
        entity.OnDeath -= Clear;
        entity.OnHealthLost -= PlayHealthGainedAnimation;
        entity.OnHealthGained -= PlayHealthGainedAnimation;
        PlayExitAnimation();

        entity = null;
    }

    private void PlayEnterAnimation()
    {
        // TODO
    }

    private void PlayExitAnimation()
    {
        // TODO
    }

    private void PlayHealthGainedAnimation(int currentHealth)
    {
        // TODO
    }

    private void PlayHealthLostAnimation(int currentHealth)
    {
        // TODO
    }
}
