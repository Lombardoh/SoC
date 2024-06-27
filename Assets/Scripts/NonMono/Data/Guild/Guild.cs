using System.Collections.Generic;

public class Guild : Settlement
{
    public Guild(Dictionary<ResourceType, int> resources, int growth): base(resources, growth)
    {
        Resources = new Dictionary<ResourceType, int>(resources);
        Growth = growth;
    }
}
