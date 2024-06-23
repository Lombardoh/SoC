using UnityEngine;

public class MonsterDenUnitsManager : SettlementUnitsManager
{
    public void UpdatePopulation()
    {
        NPCManager unit = CreateUnit();
        GameObject assignedTarget = new(unit + " AssignedTarget");
        assignedTarget.transform.position = GameUtils.GetRandomPosition(unit.transform.position, 5f, 10f);
        unit.Target = assignedTarget;
        unit.NextAssignedTask = UnitTaskType.Wandering;
        unit.CharacterStateManager.OnSelectNextState(unit.NextAssignedTask);
    }
}
