public class MonsterDenManager : SettlementManager
{
    MonsterDenUnitsManager cityUnitsManager;
    protected override void Awake()
    {
        base.Awake();
        cityUnitsManager = settlementUnitsManager as MonsterDenUnitsManager;
    }
    public override void OnTicked()
    {
        growPopulation += settlement.Growth;
        if (growPopulation > Constants.populationGrowThreshold && Constants.populationGrowLimit > settlement.Resources[ResourceType.Population])
        {
            settlement.Resources[ResourceType.Population] += 1;
            growPopulation = 0;
            cityUnitsManager.UpdatePopulation();

        }
    }
}
