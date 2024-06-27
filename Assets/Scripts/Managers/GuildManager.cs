public class GuildManager : SettlementManager
{
    public Guild Guild {  get; private set; }
    protected override void Awake()
    {
        base.Awake();
        //settlement = SettlementFactory.CreateSettlement(settlementType, 0);
    }
}
