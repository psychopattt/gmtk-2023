using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : StatusEffect
{

    private void Start()
    {
        setStatuesName("strenght");
    }
    // Start is called before the first frame update
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

}
