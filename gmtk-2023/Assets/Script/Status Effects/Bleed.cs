using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : StatusEffect
{
    private void Start()
    {
        setStatuesName("bleed");
    }

    public void applyStack(Entity target, int amountOfPoison)
    {
        List<StatusEffect> currentEffect = target.Stats.ListStatuesEffect;

        int indexToAdd = IndexOfStatusEffect(currentEffect, this);

        if (indexToAdd == -1)
        {
            this.addStack(amountOfPoison);
            currentEffect.Add(this);

        }
        
        currentEffect[indexToAdd].addStack(amountOfPoison);
        
        
    }

    public int calculateBleedDamage(Entity target)
    {
        int amountOfHit = getStack() / 100;
        if (amountOfHit > 5){
            amountOfHit = 5;
        }
        //applyStack(target, amountOfHit * 100);

        return (2000 * amountOfHit);
    }
}
