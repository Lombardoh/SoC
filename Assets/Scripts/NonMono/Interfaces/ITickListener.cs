using UnityEngine;

public interface ITickListener
{
    void SubscribeToTicks(TickTime tickTime);
    void UnsubscribeToTicks();
    void OnTicked();
}