using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private ScriptableCharacterStat stats;

    public event Action<int> OnHealthLost;
    public event Action<int> OnHealthGained;
    public event Action OnDeath;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public ScriptableCharacterStat GetStats() => stats;

    public void Damage(int damageAmount)
    {
        stats.Damage(damageAmount);
        int currenHealth = stats.GetHealth();

        if (currenHealth < 0)
        {
            OnDeath?.Invoke();
        }
        else
        {
            if (damageAmount > 0)
                OnHealthLost?.Invoke(currenHealth);
            else
                OnHealthGained?.Invoke(currenHealth);
        }
    }

    public static bool operator ==(Entity entity1, Entity entity2)
    {
        return entity1.GetInstanceID() == entity2.GetInstanceID();
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
