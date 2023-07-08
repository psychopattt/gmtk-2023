using UnityEngine;

public class EntitySlot : MonoBehaviour
{
    private Entity entity = null;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public bool IsAvailable() => entity == null;

    public Entity GetEntity() => entity;

    public void SetEntity(Entity entity)
    {
        this.entity = entity;
        spriteRenderer.sprite = entity.Stats.Sprite;
        
        SubscribeToEvents();
        PlayEnterAnimation();
    }

    private void SubscribeToEvents()
    {
        entity.OnDeath += Clear;
        entity.OnHealthLost += PlayHealthLostAnimation;
        entity.OnHealthGained += PlayHealthGainedAnimation;
    }

    public void Clear()
    {
        UnsubscribeFromEvents();
        PlayExitAnimation();
        entity = null;
    }

    private void UnsubscribeFromEvents()
    {
        entity.OnDeath -= Clear;
        entity.OnHealthLost -= PlayHealthGainedAnimation;
        entity.OnHealthGained -= PlayHealthGainedAnimation;
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
