using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blind : StatusEffect
{
    //blindEffect need to be float so ignore amount in StatuesEffect
    private void Start()
    {
        setStatuesName("blind");
    }
    [SerializeField]
    float blindEffect = 0;
    
    [SerializeField]
    private float maxBlind = 0.95f;
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
    public void addBlind(Entity target, float amountOfBlind)
    {
        List<StatusEffect> currentEffect = target.Stats.ListStatuesEffect;

        int indexToAdd = IndexOfStatusEffect(currentEffect, this);

        if (indexToAdd == -1)
        {
            Debug.Log("Error noBlindEffectAttach");
        }

        if (amountOfBlind + blindEffect > maxBlind)
        {
            Blind targetEffect = (Blind)currentEffect[indexToAdd];
            targetEffect.blindEffect = targetEffect.maxBlind;
            
        }
        else
        {
            Blind targetEffect = (Blind)currentEffect[indexToAdd];
            targetEffect.blindEffect += amountOfBlind;
        }
    }
}
