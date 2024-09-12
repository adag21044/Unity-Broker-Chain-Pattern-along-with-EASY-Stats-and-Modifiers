using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat health = new Stat(100);
    public Stat damage = new Stat(10);
    public Stat defense = new Stat(5);

    private void Start()
    {
        // Modifiers
        health.AddModifier(BuffHealth);
        health.AddModifier(DebuffAttack);
    }
    
    // Modifier functions
    private float BuffHealth(float current)
    {
        return current * 1.2f; // Increase health by 20%
    }

    private float DebuffAttack(float current)
    {
        return current * 0.8f; // Decrease attack by 20%
    }

    public void PrintStats()
    {
        Debug.Log("Health: " + health.Value);
        Debug.Log("Damage: " + damage.Value);
        Debug.Log("Defense: " + defense.Value);
    }
}