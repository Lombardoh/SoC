using UnityEngine;

public class MonsterDenUnitsManager : SettlementUnitsManager
{
    public void UpdatePopulation()
    {
        NPCManager unit = CreateUnit();
        unit.NextAssignedTask = UnitTaskType.Wandering;
        unit.CharacterStateManager.OnSelectNextState(unit.NextAssignedTask);
    }
}
