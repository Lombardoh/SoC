using System;

public static class UnitEvents
{
    public static Action OnRequestUnit;
    public static Action<Action<int>> OnCheckPopulation;
}
