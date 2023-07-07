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

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }
}
