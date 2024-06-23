public class MonsterDenUnitsManager : SettlementUnitsManager
{
    public void UpdatePopulation()
    {
        NPCManager unit = CreateUnit();
        unit.TargetPosition = GameUtils.GetRandomPosition(transform.position, 10f);
        unit.AssignedTask = UnitTaskType.Wandering;
        unit.CharacterStateManager.OnStateChangeRequested(CharacterState.Following);
    }
}
