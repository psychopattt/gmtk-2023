using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableCharacterStat : ScriptableObject
{
    [SerializeField] private string displayName;

    public string DisplayName
    {
        get => displayName;
        set => displayName = value;
    }

    [SerializeField] private EntityType type;

    public EntityType Type
    {
        get => type;
        set => type = value;
    }

    [SerializeField] private Sprite sprite;

    public Sprite Sprite
    {
        get => sprite;
        set => sprite = value;
    }

    [SerializeField] private int health;

    public int Health
    {
        get => health;
        set => health = value;
    }

    [SerializeField] private List<Attack> attacks;

    public List<Attack> Attacks
    {
        get => attacks;
        set => attacks = value;
    }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
    }
}
