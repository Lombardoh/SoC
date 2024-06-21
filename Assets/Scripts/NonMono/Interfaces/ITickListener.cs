public interface ITickListener
{
    public void SubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRegisterTickListenerRequested.Invoke(this, tickTime);
    }    
    public void UnsubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRemoveTickListenerRequested.Invoke(this, tickTime);
    }
    public void OnTicked();
}