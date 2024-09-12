using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField] private float baseValue;    
    private List<IModifier> modifiers = new List<IModifier>();

    public Stat(float baseValue)
    {
        this.baseValue = baseValue;
    }

    public float GetValue()
    {
        float finalValue = baseValue;
        
        if (modifiers != null)  // Check if the list is not null
        {
            foreach(var modifier in modifiers)
            {
                finalValue = modifier.Modify(finalValue);
            }
        }

        return finalValue;
    }

    public void AddModifier(IModifier modifier)
    {
        if (modifier == null) 
        {
            Debug.LogError("Cannot add a null modifier");
            return;
        }

        // Ensure the list is initialized
        if (modifiers == null)
        {
            modifiers = new List<IModifier>();
        }

        modifiers.Add(modifier);
        Debug.Log($"Modifier added: {modifier.GetType().Name}");
    }

    public void RemoveModifier(IModifier modifier)
    {
        if (modifier == null) 
        {
            Debug.LogError("Cannot remove a null modifier");
            return;
        }
        if (modifiers.Remove(modifier))
        {
            Debug.Log($"Modifier removed: {modifier.GetType().Name}");
        }
        else
        {
            Debug.LogWarning($"Modifier not found: {modifier.GetType().Name}");
        }
    }
}