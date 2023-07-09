using System.Collections.Generic;
using UnityEngine;


public class Poison : StatusEffect
{
    private void Start()
    {
        setStatuesName("poison");
    }
    [SerializeField]
    private int poisonDamage = 50;

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
