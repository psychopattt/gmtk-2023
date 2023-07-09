using UnityEngine;
using UnityEngine.UI;

public class EntitySlot : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject damageNumberPrefab;
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

        if (entity.Stats.Type == EntityType.Mob)
        {
            healthBarCanvas.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0.005f * entity.Stats.Sprite.rect.height, 0);
            healthBar.value = entity.Stats.Health / (float)entity.Stats.MaxHealth;
            healthBar.gameObject.SetActive(true);
            transform.position = position + new Vector3(Random.Range(-200, 200), Random.Range(-20, 20), 0);
        }
        else
        {
            healthBarCanvas.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0.8f, 0);
            transform.position = position + new Vector3(Random.Range(-80, 20), 70, 0);
            transform.localScale = new Vector3(400, 400, transform.localScale.z);
            healthBarCanvas.transform.localScale = new Vector3(
                healthBarCanvas.transform.localScale.x * 1.5f,
                healthBarCanvas.transform.localScale.y * 1.5f,
                healthBarCanvas.transform.localScale.z * 1.5f
            );
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
        entity.OnHealthChanged += HandleHealthChanged;
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
        entity.OnHealthChanged -= HandleHealthChanged;
    }

    private void PlayEnterAnimation()
    {
        // TODO entity slot EnterAnimation
    }

    private void PlayExitAnimation()
    {
        // TODO entity slot ExitAnimation
    }

    private void HandleHealthChanged(int damageAmount, DamageType damageType)
    {
        if (entity.Stats.Type == EntityType.Mob)
        {
            healthBar.value = entity.Stats.Health / (float)entity.Stats.MaxHealth;
        }
        else
        {
            playerHealthBar.SetEntity(entity);
        }

        DamageNumber damageNumber = Instantiate(damageNumberPrefab, healthBarCanvas.transform).GetComponent<DamageNumber>();
        damageNumber.StartAnimation(damageAmount, damageType);
    }
}
