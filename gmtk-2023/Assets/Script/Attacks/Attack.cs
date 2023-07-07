using UnityEngine;

[CreateAssetMenu]
public class Attack : ScriptableObject
{
    [SerializeField]
    private string attackName;

    [SerializeField]
    private int damage;

    [SerializeField]
    private int targetAmount; // Target multiple enemies

    [SerializeField]
    private int attackAmount; // For multi-hit attacks

    [SerializeField]
    private StatusEffect[] statusEffects;
}
