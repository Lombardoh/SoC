using System.Collections.Generic;

public class Settlement
{
    public Dictionary<ResourceType, int> Resources { get; set; } = new();
    public float Growth { get; set; }

    public Settlement(Dictionary<ResourceType, int> resources, int growth)
    {
        Growth = growth;
        Resources = new Dictionary<ResourceType, int>(resources);
    }
}
