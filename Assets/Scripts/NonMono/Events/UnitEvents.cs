using System;

public static class UnitEvents
{
    public static Action<Action<CharacterManager>> OnRequestUnit;
    public static Action<Action<int>> OnCheckPopulation;
}
