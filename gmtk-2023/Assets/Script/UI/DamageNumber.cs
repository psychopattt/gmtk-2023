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

    public void StartAnimation(int damageAmount)
    {
        Vector2 randomStartOffset = new Vector2(Random.Range(-randomOffset, randomOffset), Random.Range(-randomOffset, randomOffset));
        damageStartPosition += randomStartOffset;

        Vector2 randomEndOffset = new Vector2(Random.Range(-randomOffset, randomOffset), Random.Range(-randomOffset, randomOffset));
        damageEndPosition += randomEndOffset;

        rectTransform.anchoredPosition = damageStartPosition + randomStartOffset;

        damageText.text = damageAmount.ToString();
        SetColor(damageAmount);
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

    private void SetColor(int damageAmount)
    {
        damageText.color = damageAmount < 0 ? Color.green : Color.red;
    }
}
