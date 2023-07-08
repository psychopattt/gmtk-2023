using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public abstract class StatusEffect : MonoBehaviour
{
    [SerializeField]
    private string statusName = "basicEffect";
    [SerializeField]
    private int amountOfStack = 0;

    public void addStack(int stack)
    {
        amountOfStack += stack;
    }
    public void setStack (int stack)
    {
        amountOfStack = stack;
    }
    public int getStack()
    {
        return amountOfStack;
    }

    public bool DoesStatusAlreadyExist(List<StatusEffect> currentEffect, StatusEffect EffectToSearch)
    {
        foreach (StatusEffect effect in currentEffect)
        {
            if (effect.name == EffectToSearch.name)
            {
                return true;
            }
        }
        return false;
    }
    public int IndexOfStatusEffect(List<StatusEffect> currentEffect, StatusEffect EffectToSearch)
    {
        if (DoesStatusAlreadyExist(currentEffect, EffectToSearch)) return -1;

        for (int i =0; i < currentEffect.Count(); i++)
        {
            if (currentEffect[i].name == EffectToSearch.name)
            {
                return i;
            }
        }
        //something went wrong
        return -1;
    }

    public int getAmountOfStack()
    {
        return amountOfStack;
    }
}
