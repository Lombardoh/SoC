using System.Collections.Generic;

public class City
{
    public int Population { get; set; }
    public float Growth { get; set; }
    private Dictionary<ResourceType, int> resources = new();


    public City(int population, float growth, int wood, int stone)
    {
        Population = population;
        Growth = growth;
        resources[ResourceType.Stone] = stone;
        resources[ResourceType.Wood] = wood;
    }

    public ResourceType GetResourceWithLowestAmount()
    {
        int lowestAmount = int.MaxValue;
        ResourceType lowestResource = ResourceType.Wood;

        foreach (var kvp in resources)
        {
            if (kvp.Value < lowestAmount)
            {
                lowestAmount = kvp.Value;
                lowestResource = kvp.Key;
            }
        }

        return lowestResource;
    }
}

