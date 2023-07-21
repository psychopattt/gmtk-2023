using UnityEngine;
using UnityEngine.UI;

public class EntitySlot : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject damageNumberPrefab;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private Image arrow;

    private PlayerHealthBar playerHealthBar;
    private Entity entity = null;
    private Canvas healthBarCanvas;
    private Vector3 position;

    private sbyte animTarget = -1;
    private Vector3 hitStartPosition;
    private Vector3 hitEndPosition;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        ResetMobHint();
        healthBar.gameObject.SetActive(false);
        healthBarCanvas = healthBar.GetComponentInParent<Canvas>();
        healthBarCanvas.worldCamera = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();
        playerHealthBar = GetComponentInParent<PlayerHealthBar>();
    }

    public bool IsAvailable() => entity == null;

    public Entity GetEntity() => entity;

    public void SetMobHint()
    {
        arrow.gameObject.SetActive(true);
    }

    public void ResetMobHint()
    {
        arrow.gameObject.SetActive(false);
    }

    public void SetEntity(Entity entity)
    {
        this.entity = entity;

        if (entity.Stats.Animator != null)
        {
            animator.runtimeAnimatorController = entity.Stats.Animator;
            animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, -1, Random.Range(0.0f, 1.0f));
        }
        else
            spriteRenderer.sprite = entity.Stats.Sprite;

        if (entity.Stats.Type == EntityType.Mob)
        {
            healthBarCanvas.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0.005f * entity.Stats.Sprite.rect.height, 0);
            healthBar.value = entity.Stats.Health / (float)entity.Stats.MaxHealth;
            healthBar.gameObject.SetActive(true);

            Vector3 newPosition = position + new Vector3(Random.Range(-200, 200), Random.Range(-20, 20), 0);
            newPosition = new Vector3(newPosition.x, System.Math.Min(newPosition.y, 330), newPosition.z);
            transform.position = newPosition;
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

        hitStartPosition = transform.position;
        RandomizeKnockbackAmount();

        AddEventListeners();
        PlayEnterAnimation();
    }

    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }

    public Vector3 GetPosition() => position;

    private void AddEventListeners()
    {
        entity.OnDeath += Clear;
        entity.OnHealthChanged += HandleHealthChanged;
    }

    public void Clear()
    {
        if (entity != null)
        {
            ResetMobHint();
            RemoveEventListeners();
            PlayExitAnimation();
            entity = null;
            animTarget = -1;
            spriteRenderer.sprite = null;
            animator.runtimeAnimatorController = null;
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

    private void RandomizeKnockbackAmount()
    {
        if (entity.Stats.Type == EntityType.Mob)
            hitEndPosition = hitStartPosition + new Vector3(Random.Range(15f, 24f), Random.Range(-8f, 8f), 0);
        else
            hitEndPosition = hitStartPosition + new Vector3(Random.Range(-24f, -15f), Random.Range(-8f, 8f), 0);
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

        if (damageAmount > 0)
        {
            RandomizeKnockbackAmount();
            animTarget = 0;
        }

        DamageNumber damageNumber = Instantiate(damageNumberPrefab, healthBarCanvas.transform).GetComponent<DamageNumber>();
        damageNumber.StartAnimation(damageAmount, damageType);
    }

    private void Update() => MoveRectTowardsTarget();

    private void MoveRectTowardsTarget()
    {
        if (animTarget != -1)
        {
            Vector3 targetPosition = (animTarget == 0 ? hitEndPosition : hitStartPosition);

            if (Vector3.Distance(transform.position, targetPosition) > 1)
            {
                transform.position = Vector3.SmoothDamp(
                    transform.position,
                    targetPosition,
                    ref velocity,
                    0.1f
                );
            }
            else
            {
                if (animTarget == 0)
                    animTarget = 1;
                else if (animTarget == 1)
                    animTarget = -1;

                transform.position = targetPosition;
            }
        }
    }
}
