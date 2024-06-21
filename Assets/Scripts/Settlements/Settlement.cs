using System.Collections.Generic;

public class Settlement
{
    public Dictionary<ResourceType, int> Resources { get; set; } = new();
    public float Growth { get; set; }
}
