using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class Stat 
{
    [SerializeField] private float baseValue;    
    private Broker broker;
    public float modifiedValue { get; private set; }

    public Stat(float baseValue, Broker broker)
    {
        this.baseValue = baseValue;
        this.broker = broker ?? throw new System.ArgumentNullException(nameof(broker));
        modifiedValue = baseValue;
    }

    public float GetValue()
    {
        if (broker == null)
        {
            Debug.LogError("Broker is null in Stat class!");
            return baseValue;
        }

        modifiedValue = broker.ApplyModifiers(baseValue);
        Debug.Log($"[STAT] Current Value: {modifiedValue}");
        return modifiedValue;
    }

    public void UpdateStat(float deltaTime)
    {
        Debug.Log($"[STAT] Updating stats over time...");
        broker?.UpdateModifiers(deltaTime);
        GetValue();
    }
}
