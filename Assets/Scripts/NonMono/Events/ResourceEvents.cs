using System;
public static class ResourceEvents
{
    public static Action<int> OnUpdatePopulation;
    public static Action<SettlementManager> OnUpdateBuildingUIManager;
    public static Action<Action<ResourceType>> OnGetLowestResource;
}
