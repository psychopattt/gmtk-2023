using System;
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
