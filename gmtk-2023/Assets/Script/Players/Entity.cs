using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private EntityStats stats;

    public event Action<int> OnHealthLost;
    public event Action<int> OnHealthGained;
    public event Action OnDeath;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public EntityStats Stats
    {
        get => stats;
    }

    public void Damage(int damageAmount)
    {
        stats.Damage(damageAmount);
        int currentHealth = stats.Health;

        if (currentHealth < 0)
        {
            OnDeath?.Invoke();
        }
        else
        {
            if (damageAmount > 0)
                OnHealthLost?.Invoke(currentHealth);
            else
                OnHealthGained?.Invoke(currentHealth);
        }
    }

    public void Attack(Entity[] entities, Attack attack)
    {
        //stats.Type;
        for (int i = 0; i < entities.Length; i++)
        {
            DoAttack(entities[i], attack);
        }
    }
    public void DoAttack(Entity entity, Attack attack)
    {
        entity.AddStackStatusEffect(entity, attack);
        entity.Damage(attack.AttackAmount);
    }
    public void AddStackStatusEffect(Entity entity, Attack attack)
    {
        if (attack.StatusEffects.Length == 0) return;
        for (int i = 0; i < attack.StatusEffects.Length; i++)
        {
            for (int y = 0; y < entity.stats.ListStatuesEffect.Count(); y++)
            {
                if (attack.StatusEffects[i].name == entity.stats.ListStatuesEffect[i].name)
                {
                    entity.stats.ListStatuesEffect[i].addStack(attack.StatusEffects[i].getStack());
                }
            }
        }
    }

    public void ApplyStartTurnEffect()
    {
        //apply poison
        foreach (StatusEffect effect in stats.ListStatuesEffect)
        {
            if(effect is Poison)
            {
                Poison poison = (Poison)effect;
                stats.Health -= poison.calculateDamage();
                if( stats.Health <= 0)
                {
                    OnDeath?.Invoke();
                }
            }
        }
    }
    public static bool operator ==(Entity entity1, Entity entity2)
    {
        if (entity1 is null && entity2 is null)
            return true;
        else if (entity1 is null || entity2 is null)
            return false;
        else
            return  entity1.GetInstanceID() == entity2.GetInstanceID();
    }

    public static bool operator !=(Entity entity1, Entity entity2)
    {
        return !(entity1 == entity2);
    }

    public override bool Equals(object other) // Needed to override ==
    {
        return this == (Entity)other;
    }

    public override int GetHashCode() // Needed to override ==
    {
        return base.GetHashCode();
    }
}
