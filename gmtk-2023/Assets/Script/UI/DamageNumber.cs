using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text damageText;
    private RectTransform rectTransform;

    private const int randomOffset = 25;

    private Vector2 damageStartPosition = new Vector2(50, -150);
    private Vector2 damageEndPosition = new Vector2(300, 150);
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        gameObject.SetActive(false);
        rectTransform = GetComponent<RectTransform>();
    }

    public void StartAnimation(int damageAmount, DamageType damageType)
    {
        Vector2 randomStartOffset = new Vector2(Random.Range(-randomOffset, randomOffset), Random.Range(-randomOffset, randomOffset));
        damageStartPosition += randomStartOffset;

        Vector2 randomEndOffset = new Vector2(Random.Range(-randomOffset, randomOffset), Random.Range(-randomOffset, randomOffset));
        damageEndPosition += randomEndOffset;

        rectTransform.anchoredPosition = damageStartPosition + randomStartOffset;

        damageText.text = damageAmount.ToString();
        SetColor(damageAmount, damageType);
        gameObject.SetActive(true);
    }

    private void Update() => MoveRectTowardsTarget();

    private void MoveRectTowardsTarget()
    {
        if (Vector3.Distance(rectTransform.anchoredPosition, damageEndPosition) > 6)
        {
            rectTransform.anchoredPosition = Vector3.SmoothDamp(
                rectTransform.anchoredPosition,
                damageEndPosition,
                ref velocity,
                0.5f
            );
        }
        else
        {
            rectTransform.anchoredPosition = damageEndPosition;
            Destroy(gameObject);
        }
    }

    private void SetColor(int damageAmount, DamageType damageType)
    {
        if (damageAmount < 0)
        {
            damageText.color = new Color32(0, 200, 0, 255);
        }
        else
        {
            switch (damageType)
            {
                case DamageType.Normal:
                    damageText.color = new Color32(200, 200, 200, 255);
                    break;
                case DamageType.Crit:
                    damageText.color = new Color32(200, 200, 0, 255);
                    break;
                case DamageType.Poison:
                    damageText.color = new Color32(153, 51, 153, 255);
                    break;
                case DamageType.Bleed:
                    damageText.color = new Color32(200, 0, 0, 255);
                    break;
                case DamageType.Self:
                    damageText.color = new Color32(228, 27, 113, 255);
                    break;
            }
        }
    }
}
