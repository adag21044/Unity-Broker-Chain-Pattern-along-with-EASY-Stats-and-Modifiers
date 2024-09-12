using UnityEngine;

public class HealthBuffModifier : IStatModifier
{
    public void Modify(CharacterStats stats)
    {
        stats.health.AddModifier(current => current + 20); // Increase health by 20
        Debug.Log("Health Buff Modifier applied.");
    }
}
