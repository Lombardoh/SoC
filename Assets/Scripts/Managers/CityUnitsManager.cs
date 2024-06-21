
public class CityUnitsManager : SettlementUnitsManager
{
    public void UpdatePopulation()
    {
        NPCManager unit = CreateUnit();
        unit.FindWork(settlementManager.GetLowestResource());
    }
}
