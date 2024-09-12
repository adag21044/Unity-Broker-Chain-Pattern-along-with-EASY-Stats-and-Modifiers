using System.Collections.Generic;
using UnityEngine;
public class Broker 
{
    private List<Stat> stats = new List<Stat>();

    public void AddStat(Stat stat)
    {
        stats.Add(stat);
        Debug.Log($"Stat added to broker");
    }

    public void ProcessAllStats()
    {
        foreach(var stat in stats)
        {
            Debug.Log($"Stat value: {stat.GetValue()}");
        }
    }
}