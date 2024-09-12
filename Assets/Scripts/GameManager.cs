using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CharacterStats characterStats;
    private StatBroker statBroker;

    private void Start()
    {
        characterStats = FindObjectOfType<CharacterStats>();
        statBroker = new StatBroker();

        // Add modifiers
        statBroker.AddModifier(new HealthBuffModifier());
        statBroker.AddModifier(new AttackDebuffModifier());

        // Apply modifiers explicitly
        ApplyModifiers();
    }

    public void ApplyModifiers()
    {
        statBroker.ApplyModifiers(characterStats);
        characterStats.PrintStats();
    }
}
