using UnityEngine;

public class AttackDebuffModifier : IStatModifier
{
    public void Modify(CharacterStats stats)
    {
        stats.damage.AddModifier(current => current * 0.8f); // Decrease attack by 20%
    }
}