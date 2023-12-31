using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private string attackName;
    public string AttackName
    {
        get { return attackName; }
        set { attackName = value; }
    }

    [SerializeField]
    private bool selfTargetting;
    public bool SelfTargetting
    {
        get { return selfTargetting; }
        set { selfTargetting = value; }
    }

    [SerializeField]
    private bool cleave;
    public bool Cleave
    {
        get { return cleave; }
        set { cleave = value; }
    }

    [SerializeField]
    private int damage;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    [SerializeField]
    private int critMultiplier = 2; // Target multiple enemies

    public int CritMultiplier
    {
        get { return critMultiplier; }
        set { critMultiplier = value; }
    }
    [SerializeField]
    private int critChance = 10; // Target multiple enemies

    public int CritChance
    {
        get { return critChance; }
        set { critChance = value; }
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
    private int selfDamage;

    public int SelfDamage
    {
        get { return selfDamage; }
        set { selfDamage = value; }
    }

    [SerializeField]
    private StatusEffect[] statusEffects;

    
    public StatusEffect[] StatusEffects
    {
        get { return statusEffects; }
        set { statusEffects = value; }
    }

    public AudioSource soundEffect;

    public AudioClip sfx;

    public void playClip()
    {
        if (soundEffect == null) { return; }
        soundEffect.clip = sfx;
        soundEffect.Play();
    }

}
