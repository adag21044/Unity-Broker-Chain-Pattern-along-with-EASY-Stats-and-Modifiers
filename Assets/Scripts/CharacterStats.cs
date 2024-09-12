using UnityEngine;
using TMPro;

public class CharacterStats : MonoBehaviour, IStateObserver
{
    public Stat health = new Stat(100);
    public Stat damage = new Stat(10);
    public Stat defense = new Stat(5);

    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text defenseText;

    private void Start()
    {
        // Register observers
        health.AddObserver(this);
        damage.AddObserver(this);
        defense.AddObserver(this);

        PrintStats();
    }

    public void IncreaseHealth() => health.AddModifier(value => value + 10);
    public void DecreaseHealth() => health.AddModifier(value => value - 10);
    public void IncreaseDamage() => damage.AddModifier(value => value + 5);
    public void DecreaseDamage() => damage.AddModifier(value => value - 5);
    public void IncreaseDefense() => defense.AddModifier(value => value + 2);
    public void DecreaseDefense() => defense.AddModifier(value => value - 2);

    public void PrintStats()
    {
        healthText.text = $"Health: {health.Value}";
        damageText.text = $"Damage: {damage.Value}";
        defenseText.text = $"Defense: {defense.Value}";

        Debug.Log($"Health: {health.Value}");
        Debug.Log($"Damage: {damage.Value}");
        Debug.Log($"Defense: {defense.Value}");
    }

    public void OnStatChanged()
    {
        PrintStats();
    }
}
