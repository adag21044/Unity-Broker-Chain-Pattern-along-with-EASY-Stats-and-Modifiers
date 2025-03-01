public class DefenseModifier : IModifier
{
    private readonly float defenseBoost;

    public DefenseModifier(float defenseBoost)
    {
        this.defenseBoost = defenseBoost;
    }

    public int GetPriority() => 3;

    public float Modify(float value)
    {
        return value + defenseBoost;
    }
}