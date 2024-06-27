using System;
using UnityEngine;
public static class BuildingEvents
{
    public static Action<SettlementManager> OnBuildingSelected;
    public static Action<SettlementManager> OnUpdateSelectedBuilding;
}
