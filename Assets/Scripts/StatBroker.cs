using System.Collections.Generic;

public class StatBroker 
{
    private readonly List<IStatModifier> modifers = new List<IStatModifier>();

    public void AddModifier(IStatModifier modifier)
    {
        modifers.Add(modifier);
    }

    public void RemoveModifier(IStatModifier modifier)
    {
        modifers.Remove(modifier);
    }

    public void ApplyModifiers(CharacterStats stats)
    {
        foreach (var modifier in modifers)
        {
            modifier.Modify(stats);
        }
    }
}