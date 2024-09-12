public class DefenseModifier : IModifier
{
    private readonly float defenseBoost;

    public DefenseModifier(float defenseBoost)
    {
        this.defenseBoost = defenseBoost;
    }

    public float Modify(float value)
    {
        return value + defenseBoost;
    }
}