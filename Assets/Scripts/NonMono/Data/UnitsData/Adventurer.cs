using System.Collections.Generic;
using UnityEngine;
public class Adventurer : Unit
{
    public Dictionary<StatType, int> stats = new();
    public Adventurer(int resourceAmount, int resourceCapacity, Dictionary<StatType, int> stats) : base(resourceAmount, resourceCapacity)
    {
        foreach(var stat in stats)
        {
            Debug.Log(stat);
        }
    }
}
