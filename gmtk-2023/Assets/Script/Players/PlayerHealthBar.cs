using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider playerHealthBar;

    public void SetEntity(Entity entity)
    {
        playerHealthBar.maxValue = entity.Stats.MaxHealth;
        playerHealthBar.value = entity.Stats.Health;
    }
}