public class CityManager : SettlementManager
{
    CityUnitsManager cityUnitsManager;
    protected override void Awake()
    {
        base.Awake();
        cityUnitsManager = settlementUnitsManager as CityUnitsManager;
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
