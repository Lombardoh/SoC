using System.Collections.Generic;

public interface IResource
{
    public Dictionary<ResourceType, int> GetResources();
    public ResourceType GetLowestResource();
}
