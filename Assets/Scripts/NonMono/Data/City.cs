using System.Collections.Generic;

public class City: Settlement
{
    
    public City(int population, float growth, int wood, int stone)
    {
        Growth = growth;
        Resources[ResourceType.Population] = population;
        Resources[ResourceType.Wood] = wood;
        Resources[ResourceType.Stone] = stone;
    }
    public ResourceType GetResourceWithLowestAmount()
    {
        int lowestAmount = int.MaxValue;
        ResourceType lowestResource = ResourceType.Wood;

        foreach (var kvp in Resources)
        {
            if (kvp.Key == ResourceType.Nothing || kvp.Key == ResourceType.Population) { continue; }
            if (kvp.Value < lowestAmount)
            {
                lowestAmount = kvp.Value;
                lowestResource = kvp.Key;
            }
        }

        return lowestResource;
    }
}

