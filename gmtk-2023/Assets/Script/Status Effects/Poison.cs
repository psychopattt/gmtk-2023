using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Poison : StatusEffect
{
    [SerializeField]
    private int poisonDamage = 70;

    public void applyStack(Entity target, int amountOfPoison)
    {
        List<StatusEffect> currentEffect = target.Stats.ListStatuesEffect;

        int indexToAdd = IndexOfStatusEffect(currentEffect, this);

        if (indexToAdd == -1) {
            this.addStack(amountOfPoison);
            currentEffect.Add(this);

        }

        currentEffect[indexToAdd].addStack(amountOfPoison);
    }

    public int calculateDamage()
    {
        return (getAmountOfStack() * poisonDamage);
    }
}
