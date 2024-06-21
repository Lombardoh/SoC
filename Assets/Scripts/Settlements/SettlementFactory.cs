public static class SettlementFactory 
{
    public static Settlement CreateSettlement(SettlementType type)
    {
        switch (type) 
        {
            case SettlementType.City:
                return new City(0,1,0,0);            
            case SettlementType.MonsterDen:
                return new MonsterDen(0,1);
        }
        return null;
    }
}
