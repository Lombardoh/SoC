using System.Collections.Generic;
using System;

[System.Serializable]
public class SettlementData
{
    public int Population;
    public int Wood;
    public int Stone;
    public int Money;
    public int Growth;

    public Dictionary<ResourceType, int> ToResourceDictionary()
    {
        return new Dictionary<ResourceType, int>
        {
            { ResourceType.Population, Population },
            { ResourceType.Wood, Wood },
            { ResourceType.Stone, Stone },
            { ResourceType.PeronCoins, Money }
        };
    }
}
