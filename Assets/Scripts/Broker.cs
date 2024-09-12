using System.Collections.Generic;
using UnityEngine;

public class Broker 
{
    private readonly List<Stat> stats = new List<Stat>();

    public void AddStat(Stat stat)
    {
        if (stat == null)
        {
            Debug.LogError("Cannot add a null stat");
            return;
        }
        stats.Add(stat);
        Debug.Log("Stat added to broker");
    }

    public void ProcessAllStats()
    {
        foreach (var stat in stats)
        {
            Debug.Log($"Stat value: {stat.GetValue()}");
        }
    }
}
