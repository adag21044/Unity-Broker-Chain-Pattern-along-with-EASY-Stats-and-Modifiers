using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Stat 
{
    private float baseValue;    
    private List<IModifier> modifiers = new List<IModifier>();

    public Stat(float baseValue)
    {
        this.baseValue = baseValue;
    }

    public float GetValue()
    {
        float finalValue = baseValue;
        
        foreach(var modifier in modifiers)
        {
            finalValue = modifier.Modify(finalValue);
        }

        return finalValue;
    }

    public void AddModifier(IModifier modifier)
    {
        modifiers.Add(modifier);
        UnityEngine.Debug.Log($"Modifier added: {modifier.GetType().Name}");
    }

    public void RemoveModifier(IModifier modifier)
    {
        if(modifiers.Contains(modifier))
        {
            modifiers.Remove(modifier);
            UnityEngine.Debug.Log($"Modifier removed: {modifier.GetType().Name}");
        }
        else
        {
            UnityEngine.Debug.LogError($"Modifier not found:");
        }
    }
}