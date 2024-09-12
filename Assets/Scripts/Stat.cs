using System;
using System.Collections.Generic;


public class Stat 
{
    private float baseValue;
    private readonly List<Func<float, float>> modifiers = new List<Func<float, float>>();

    public Stat(float baseValue)
    {
        this.baseValue = baseValue;
    }

    public float Value
    {
        get
        {
            float finalValue = baseValue;
            modifiers.ForEach(modifier => finalValue = modifier(finalValue));
            return finalValue;
        }
    }

    public void AddModifier(Func<float, float> modifier)
    {
        modifiers.Add(modifier);
    }

    public void RemoveModifier(Func<float, float> modifier)
    {
        modifiers.Remove(modifier);
    }
}
