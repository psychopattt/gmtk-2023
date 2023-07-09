using System.Collections.Generic;
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


    [SerializeField] private RuntimeAnimatorController animator;

    public RuntimeAnimatorController Animator
    {
        get => animator;
        set => animator = value;
    }

    [SerializeField] private Sprite sprite;

    public Sprite Sprite
    {
        get => sprite;
        set => sprite = value;
    }

    [SerializeField] private int maxHealth; //im sorry but this makes the health bar work

    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    [SerializeField] private int health; //im sorry but this makes the health bar work

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
