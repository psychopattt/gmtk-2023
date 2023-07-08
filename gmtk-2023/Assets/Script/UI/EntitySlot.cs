using UnityEngine;
using UnityEngine.UI;

public class EntitySlot : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Entity entity = null;

    private void Awake()
    {
        healthBar.gameObject.SetActive(false);
        healthBar.GetComponentInParent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();
    }

    public bool IsAvailable() => entity == null;

    public Entity GetEntity() => entity;

    public void SetEntity(Entity entity)
    {
        this.entity = entity;
        healthBar.gameObject.SetActive(true);
        spriteRenderer.sprite = entity.Stats.Sprite;
        
        AddEventListeners();
        PlayEnterAnimation();
    }

    private void AddEventListeners()
    {
        entity.OnDeath += Clear;
        entity.OnHealthLost += PlayHealthLostAnimation;
        entity.OnHealthGained += PlayHealthGainedAnimation;
    }

    public void Clear()
    {
        if (entity != null)
        {
            RemoveEventListeners();
            PlayExitAnimation();
            entity = null;
        }
    }

    private void RemoveEventListeners()
    {
        entity.OnDeath -= Clear;
        entity.OnHealthLost -= PlayHealthGainedAnimation;
        entity.OnHealthGained -= PlayHealthGainedAnimation;
    }

    private void PlayEnterAnimation()
    {
        // TODO entity slot EnterAnimation
    }

    private void PlayExitAnimation()
    {
        // TODO entity slot ExitAnimation
    }

    private void PlayHealthGainedAnimation(int currentHealth)
    {
        // TODO entity slot HealthGainedAnimation
    }

    private void PlayHealthLostAnimation(int currentHealth)
    {
        // TODO entity slot HealthLostAnimation
    }
}
