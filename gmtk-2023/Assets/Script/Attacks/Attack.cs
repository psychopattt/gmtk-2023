using UnityEngine;

[CreateAssetMenu]
public class Attack : ScriptableObject
{
    [SerializeField]
    private string attackName;
    public string AttackName
    {
        get { return attackName; }
        set { attackName = value; }
    }

    [SerializeField]
    private int damage;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    [SerializeField]
    private int targetAmount; // Target multiple enemies

    public int TargetAmount
    {
        get { return targetAmount; }
        set { targetAmount = value; }
    }

    [SerializeField]
    private int attackAmount; // For multi-hit attacks

    public int AttackAmount
    {
        get { return attackAmount; }
        set { attackAmount = value; }
    }

    [SerializeField]
    private StatusEffect[] statusEffects;

    public StatusEffect[] StatusEffects
    {
        get { return statusEffects; }
        set { statusEffects = value; }
    }

}
