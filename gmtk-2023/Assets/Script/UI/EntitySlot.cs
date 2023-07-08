using UnityEngine;
using UnityEngine.UI;

public class EntitySlot : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Entity entity = null;
    Canvas healthBarCanvas;

    private void Awake()
    {
        healthBar.gameObject.SetActive(false);
        healthBarCanvas = healthBar.GetComponentInParent<Canvas>();
        healthBarCanvas.worldCamera = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();
    }

    public bool IsAvailable() => entity == null;

    public Entity GetEntity() => entity;

    public void SetEntity(Entity entity)
    {
        this.entity = entity;
        healthBar.gameObject.SetActive(true);
        spriteRenderer.sprite = entity.Stats.Sprite;
        healthBarCanvas.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0.005f * entity.Stats.Sprite.rect.height, 0);

        AddEventListeners();
        PlayEnterAnimation();
    }

    private void AddEventListeners()
    {
        entity.OnDeath += Clear;
        entity.OnHealthLost += HandleHealthLostAnimation;
        entity.OnHealthGained += HandleHealthGainedAnimation;
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
        entity.OnHealthLost -= HandleHealthLostAnimation;
        entity.OnHealthGained -= HandleHealthGainedAnimation;
    }

    private void PlayEnterAnimation()
    {
        // TODO entity slot EnterAnimation
    }

    private void PlayExitAnimation()
    {
        // TODO entity slot ExitAnimation
    }

    private void HandleHealthGainedAnimation(int currentHealth)
    {
        // TODO entity slot HealthGainedAnimation
        healthBar.value = currentHealth / entity.Stats.MaxHealth;
    }

    private void HandleHealthLostAnimation(int currentHealth)
    {
        // TODO entity slot HealthLostAnimation
        healthBar.value = currentHealth / entity.Stats.MaxHealth;
    }
}
