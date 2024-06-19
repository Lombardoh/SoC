using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public ResourceType ResourceType { get; private set; }
    public int Amount { get; private set; }

    ResourceManager(ResourceType resourceType = ResourceType.Wood, int amount = 100)
    {
        ResourceType = resourceType;
        Amount = amount;
    }
}
