using System.Collections.Generic;

public class City : Settlement
{
    public City(Dictionary<ResourceType, int> resources, int growth) : base(resources, growth)
    {
        Resources = new Dictionary<ResourceType, int>(resources);
        Growth = growth;
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

