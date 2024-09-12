public class AttackModifier : IModifier
{
    private readonly float attackBoost;

    public AttackModifier(float attackBoost)
    {
        this.attackBoost = attackBoost;
    }

    public float Modify(float value)
    {
        return value + attackBoost;
    }
}