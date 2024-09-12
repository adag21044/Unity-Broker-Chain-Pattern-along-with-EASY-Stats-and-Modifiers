using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CharacterStats characterStats;
    private StatBroker statBroker;

    private void Start()
    {
        characterStats = FindObjectOfType<CharacterStats>();
        statBroker = new StatBroker();

        // Modifiers
        statBroker.AddModifier(new HealthBuffModifier());
        statBroker.AddModifier(new AttackDebuffModifier());

        // Apply modifiers
        statBroker.ApplyModifiers(characterStats);

        // Print stats
        characterStats.PrintStats();
    }
}