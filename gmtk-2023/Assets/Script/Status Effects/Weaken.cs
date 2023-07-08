using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weaken : StatusEffect
{
    public void applyStack(Entity target, int amountOfWeaken)
    {
        List<StatusEffect> currentEffect = target.Stats.ListStatuesEffect;

        int indexToAdd = IndexOfStatusEffect(currentEffect, this);

        if (indexToAdd == -1)
        {
            this.addStack(amountOfWeaken);
            currentEffect.Add(this);

        }

        currentEffect[indexToAdd].addStack(amountOfWeaken);
    }

    public int calculateDamageModifier()
    {
        return ((int)(3600/(getAmountOfStack() +1)) + 100);
    }
}
