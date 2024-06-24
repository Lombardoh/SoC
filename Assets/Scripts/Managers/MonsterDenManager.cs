public class MonsterDenManager : SettlementManager
{
    MonsterDenUnitsManager monsterDenUnitsManager;
    protected override void Awake()
    {
        base.Awake();
        monsterDenUnitsManager = settlementUnitsManager as MonsterDenUnitsManager;
    }
    public override void OnTicked()
    {
        growPopulation += settlement.Growth;
        if (growPopulation > Constants.populationGrowThreshold && Constants.populationGrowLimit > settlement.Resources[ResourceType.Population])
        {
            settlement.Resources[ResourceType.Population] += 1;
            growPopulation = 0;
            monsterDenUnitsManager.UpdatePopulation();
        }
    }
}
