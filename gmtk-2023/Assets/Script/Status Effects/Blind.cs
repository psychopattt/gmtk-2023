using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blind : StatusEffect
{
    //blindEffect need to be float so ignore amount in StatuesEffect
    float blindEffect = 0;
    public void applyStack(Entity target, int amountOfBlind)
    {
        List<StatusEffect> currentEffect = target.Stats.ListStatuesEffect;

        int indexToAdd = IndexOfStatusEffect(currentEffect, this);

        if (indexToAdd == -1)
        {
            this.addStack(amountOfBlind);
            currentEffect.Add(this);

        }

        currentEffect[indexToAdd].addStack(amountOfBlind);
    }
}
