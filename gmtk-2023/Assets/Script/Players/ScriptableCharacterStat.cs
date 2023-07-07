using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableCharacterStat : ScriptableObject
{
    [SerializeField]
    private string playerName;

    [SerializeField]
    private Sprite baseSprite;

    [SerializeField]
    private int health;

    [SerializeField]
    private List<Attack> attacks;

    public int getHealth()
    {
        return health;
    }
    public void Damage(int damageAmount)
    {
        this.health -= damageAmount;
    }
}
