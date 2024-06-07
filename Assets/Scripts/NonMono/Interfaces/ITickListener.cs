public interface ITickListener
{
    void SubscribeToTicks(TickTime tickTime);
    void UnsubscribeToTicks(TickTime tickTime);
    void OnTicked();
}