using System;
public static class ResourceEvents
{
    public static Action<int> OnUpdatePopulation;
    public static Action<int> UpdateUIPopulation;
    public static Action<Action<ResourceType>> OnGetLowestResource;
}
