using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text damageText;
    private RectTransform rectTransform;

    private Vector3 damageStartPosition;
    private Vector3 damageEndPosition;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        gameObject.SetActive(false);
        rectTransform = GetComponent<RectTransform>();
        damageStartPosition = rectTransform.anchoredPosition;
        damageEndPosition = damageStartPosition + new Vector3(250, 300);
        rectTransform.anchoredPosition = damageEndPosition;
    }

    public void StartAnimation(int damageAmount)
    {
        rectTransform.anchoredPosition = damageStartPosition;
        SetColor(damageAmount);
        damageText.text = damageAmount.ToString();
        gameObject.SetActive(true);
    }

    private void Update() => MoveRectTowardsTarget();

    private void MoveRectTowardsTarget()
    {
        if (Vector3.Distance(rectTransform.anchoredPosition, damageEndPosition) > 5)
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
            gameObject.SetActive(false);
        }
    }

    private void SetColor(int damageAmount)
    {
        damageText.color = damageAmount < 0 ? Color.green : Color.red;
    }
}
