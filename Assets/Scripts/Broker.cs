using System.Collections.Generic;
using UnityEngine;

public class Broker
{
    private readonly List<IModifier> modifiers = new List<IModifier>();

    public void AddModifier(IModifier modifier)
    {
        if (modifier == null)
        {
            Debug.LogError("Cannot add a null modifier");
            return;
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

    public float ApplyModifiers(float baseValue)
    {
        float modifiedValue = baseValue;
        
        Debug.Log($"[BROKER] Applying modifiers on base value: {baseValue}");

        // Modifier'ları önce sıralı şekilde uygula
        modifiers.Sort((a, b) => a.GetPriority().CompareTo(b.GetPriority()));

        foreach (var modifier in modifiers)
        {
            modifiedValue = modifier.Modify(modifiedValue);
        }

        Debug.Log($"[BROKER] Final modified value: {modifiedValue}");
        return modifiedValue;
    }

    public void UpdateModifiers(float deltaTime)
    {
        List<IModifier> expiredModifiers = new List<IModifier>();

        foreach (var modifier in modifiers)
        {
            if (modifier is TimedModifier tm)
            {
                tm.Update(deltaTime);
                if (tm.IsExpired())
                    expiredModifiers.Add(tm);
            }
        }

        foreach (var expired in expiredModifiers)
        {
            Debug.Log($"[BROKER] Timed Modifier expired: {expired.GetType().Name}");
            RemoveModifier(expired);
        }
    }
}
