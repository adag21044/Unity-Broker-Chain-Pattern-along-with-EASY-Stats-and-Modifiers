using System;
using System.Collections.Generic;
using UnityEngine;

public class Stat 
{
    private float baseValue;
    private readonly List<Func<float, float>> modifiers = new List<Func<float, float>>();
    private readonly List<IStateObserver> observers = new List<IStateObserver>();

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
        NotifyObservers();
    }

    public void AddObserver(IStateObserver observer)
    {
        observers.Add(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnStatChanged();
        }
    }
}
