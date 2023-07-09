using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EntitySlot : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private DamageNumber damageNumber;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private PlayerHealthBar playerHealthBar;
    private Entity entity = null;
    private Canvas healthBarCanvas;
    private Vector3 position;

    private void Awake()
    {
        healthBar.gameObject.SetActive(false);
        healthBarCanvas = healthBar.GetComponentInParent<Canvas>();
        healthBarCanvas.worldCamera = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();
        playerHealthBar = GetComponentInParent<PlayerHealthBar>();
    }

    public bool IsAvailable() => entity == null;

    public Entity GetEntity() => entity;

    public void SetEntity(Entity entity)
    {
        this.entity = entity;
        spriteRenderer.sprite = entity.Stats.Sprite;
        healthBarCanvas.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0.005f * entity.Stats.Sprite.rect.height, 0);
        transform.position = position + new Vector3(Random.Range(-200, 200), Random.Range(-20, 20), 0);

        if (entity.Stats.Type == EntityType.Mob)
        {
            healthBar.value = entity.Stats.Health / (float)entity.Stats.MaxHealth;
            healthBar.gameObject.SetActive(true);
        }

        AddEventListeners();
        PlayEnterAnimation();
    }

    public void SetPosition(Vector3 position)
    {
        this.position = position;
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
            spriteRenderer.sprite = null;
            healthBar.gameObject.SetActive(false);
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

    private void HandleHealthGainedAnimation(int damageAmount)
    {
        HandleHealthChanged(damageAmount);
    }

    private void HandleHealthLostAnimation(int damageAmount)
    {
        HandleHealthChanged(damageAmount);
    }

    private void HandleHealthChanged(int damageAmount)
    {
        if (entity.Stats.Type == EntityType.Mob)
        {
            healthBar.value = entity.Stats.Health / (float)entity.Stats.MaxHealth;
        }
        else
        {
            playerHealthBar.SetEntity(entity);
        }
        
        damageNumber.StartAnimation(damageAmount);
    }
}
