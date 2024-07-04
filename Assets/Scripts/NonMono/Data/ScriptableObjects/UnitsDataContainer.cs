using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnitsDataContainer : ScriptableObject
{
    [EnumNamedArray(typeof(SettlementType))]
    public List<SettlementData> data = new();
}
