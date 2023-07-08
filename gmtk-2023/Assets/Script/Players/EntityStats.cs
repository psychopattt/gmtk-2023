using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityStats : MonoBehaviour
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

    [SerializeField] private int maxHealth;

    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    [SerializeField] private int health;

    public int Health
    {
        get => health;
        set => health = value;
    }

    [SerializeField] private int weaken;
    public int Weaken
    {
        get => weaken;
        set => weaken = value;
    }

    [SerializeField] private List<Attack> attacks;

    public List<Attack> Attacks
    {
        get => attacks;
        set => attacks = value;
    }



    [SerializeField] private List<StatusEffect> listStatusEffect;

    public List<StatusEffect> ListStatuesEffect
    {
        get => listStatusEffect;
        set => listStatusEffect = value;
    }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
    }
}
