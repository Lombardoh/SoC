using System.Collections.Generic;

public interface IDepositable 
{
    public Dictionary<ResourceType, int> GetResources();
    public ResourceType GetLowestResource();
    public SettlementUIResourceManager GetCityUIResourceManager();
    public void Deposite(ResourceType resourceType, int amount)
    {
        Dictionary<ResourceType, int> resources = GetResources();
        SettlementUIResourceManager cityResourceManager = GetCityUIResourceManager();
        resources[resourceType] += amount;
        cityResourceManager.UpdateResources();
    }
}
