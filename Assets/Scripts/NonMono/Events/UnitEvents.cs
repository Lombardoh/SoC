using System;

public static class UnitEvents
{
    public static Action<Action<UnitManager>> OnRequestUnit;
    public static Action<Action<int>> OnCheckPopulation;
}
