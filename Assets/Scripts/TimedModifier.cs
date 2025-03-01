using UnityEngine;
public class TimedModifier : IModifier
{
    private readonly float value;
    private readonly float duration;
    private float timeElapsed = 0;

    public TimedModifier(float value, float duration)
    {
        this.value = value;
        this.duration = duration;
    }

    public float Modify(float baseValue)
    {
        return baseValue + value;
    }

    public bool IsExpired()
    {
        return timeElapsed >= duration;
    }

    public void Update(float deltaTime)
    {
        timeElapsed += deltaTime;
        Debug.Log($"[TIMED MODIFIER] Updating... {timeElapsed}/{duration} seconds elapsed.");
    }

    public int GetPriority() => 2;
}
