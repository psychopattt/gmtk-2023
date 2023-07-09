using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private EntityStats stats;

    [SerializeField]
    private BossMusic bossMusic;

    public event Action<int> OnHealthLost;
    public event Action<int> OnHealthGained;
    public event Action OnDeath;

    void Start()
    {
        stats.ListStatuesEffect.Add(gameObject.AddComponent<Poison>());
        stats.ListStatuesEffect.Add(gameObject.AddComponent<Blind>());
        stats.ListStatuesEffect.Add(gameObject.AddComponent<Weaken>());
        stats.ListStatuesEffect.Add(gameObject.AddComponent<Strength>());
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
        if (bossMusic != null) { 
            bossMusic.updateSound(stats.Health); 
        }
        if (damageAmount < 0)
            OnHealthGained?.Invoke(damageAmount);
        else
            OnHealthLost?.Invoke(damageAmount);

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void Attack(Entity[] entities, Attack attack)
    {
        if (entities.Length == 0)return;
        //stats.Type;
        for (int i = 0; i < attack.TargetAmount; i++)
        {
            
            int randomTarget = UnityEngine.Random.Range(0, entities.Length);
            if (entities[randomTarget].stats.Health > 0)
            {
                
                DoAttack(entities[randomTarget], attack);
            }
            
        }
    }
    public void DoAttack(Entity entity, Attack attack)
    {
        attack.playClip();
        entity.AddStackStatusEffect(entity, attack);
        bool isCrit = UnityEngine.Random.Range(0, 100) <= attack.CritChance;

        if (isCrit)
        {
            entity.Damage(attack.Damage*attack.CritMultiplier);
        }
        else
        {
            if (attack.Damage == 5000)
            {
                entity.Damage((int)Math.Min((7200 / (1 + ((2 * findWeaken()) / 5))) + 100, 5000));
            }
            else {
                entity.Damage(attack.Damage+(int)(attack.Damage*0.1f*findStrength(entity))); 
            }
        }
        
        if(attack.SelfDamage != 0)
        {
            Damage(attack.SelfDamage);
        }
    }
    public int findStrength(Entity entity)
    {
        List<StatusEffect> effectToSearch = entity.stats.ListStatuesEffect;

        foreach (StatusEffect effect in effectToSearch)
        {
            if (effect is Strength)
            {
                return effect.getStack();
            }
        }
        return 1;
    }
    public int findWeaken()
    {
        List<StatusEffect> effectToSearch = stats.ListStatuesEffect;

        foreach (StatusEffect effect in effectToSearch)
        {
            if (effect is Weaken)
            {
                return effect.getStack();
            }
        }
        return 0;
    }
    public void AddStackStatusEffect(Entity entity, Attack attack)
    {
        if (attack.StatusEffects.Length == 0) return;
        for (int i = 0; i < attack.StatusEffects.Length; i++)
        {
            for (int y = 0; y < entity.stats.ListStatuesEffect.Count(); y++)
            {
                if (attack.StatusEffects[i].getStatusName() == entity.Stats.ListStatuesEffect[y].getStatusName())
                {
                    entity.stats.ListStatuesEffect[y].addStack(attack.StatusEffects[i].StackByX);
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
                Damage(poison.calculateDamage());
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
