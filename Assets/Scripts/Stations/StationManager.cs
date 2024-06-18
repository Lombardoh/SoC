using UnityEngine;

public class StationManager : MonoBehaviour, ITickListener
{
    private Station station;
    [SerializeField] private ResourceType resourceType;
    [SerializeField] private int resourceAmount;
    private void Awake()
    {
        station = new(resourceType, resourceAmount);
    }

    public void SubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRegisterTickListenerRequested?.Invoke(this, tickTime);
    }    
    
    public void UnsubscribeToTicks()
    {
        UnsubscribeToTicks(TickTime.Large);
    }   

    public void UnsubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRemoveTickListenerRequested?.Invoke(this, tickTime);
    }

    public void OnTicked()
    {
        SubstractResource();
    }

    private void SubstractResource()
    {
        resourceAmount -= 1;
        if (resourceAmount <= 0) { Destroy(gameObject); }
    }    
}
