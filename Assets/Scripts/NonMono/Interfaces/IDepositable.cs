using System.Collections.Generic;

public interface IDepositable 
{
    public Dictionary<ResourceType, int> GetResources();
    public ResourceType GetLowestResource();
    public bool GetSelected();
    public SettlementUIResourceManager GetSettlementUIResourceManager();
    public void Deposite(ResourceType resourceType, int amount)
    {
        Dictionary<ResourceType, int> resources = GetResources();
        SettlementUIResourceManager settlementUIResourceManager = GetSettlementUIResourceManager();
        resources[resourceType] += amount;
        settlementUIResourceManager.UpdateResources();
    }
}
