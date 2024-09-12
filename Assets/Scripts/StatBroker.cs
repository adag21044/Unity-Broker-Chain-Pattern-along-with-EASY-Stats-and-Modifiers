using System.Collections.Generic;

public class StatBroker 
{
    private readonly List<IStatModifier> modifiers = new List<IStatModifier>();

    public void AddModifier(IStatModifier modifier)
    {
        modifiers.Add(modifier);
    }

    public void ApplyModifiers(CharacterStats stats)
    {
        foreach (var modifier in modifiers)
        {
            modifier.Modify(stats);
        }
    }
}
