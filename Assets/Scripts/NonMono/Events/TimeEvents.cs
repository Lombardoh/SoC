using System;

public static class TimeEvents
{
    public static Action<ITickListener, TickTime> OnRegisterTickListenerRequested;
    public static Action<ITickListener, TickTime> OnRemoveTickListenerRequested;
}
