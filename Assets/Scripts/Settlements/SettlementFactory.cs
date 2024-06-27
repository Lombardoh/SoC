using System.Collections.Generic;
using UnityEngine;

public static class SettlementFactory 
{
    public static Settlement CreateSettlement(SettlementType type, Dictionary<ResourceType, int> resources, int growth)
    {

        switch (type)
        {
            case SettlementType.City:
                return new City(resources, growth);
            case SettlementType.MonsterDen:
                return new MonsterDen(resources, growth);
            case SettlementType.Guild:
                return new Guild(resources, growth);
            default:
                break;
        }
        return null;
    }


}
