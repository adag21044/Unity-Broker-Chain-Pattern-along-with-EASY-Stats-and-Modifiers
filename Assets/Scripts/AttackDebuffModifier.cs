using UnityEngine;

public class AttackDebuffModifier : IStatModifier
{
    public void Modify(CharacterStats stats)
    {
        stats.damage.AddModifier(current => current * 0.8f); // Damage reduced by 20%
    }
}
