using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SettlementDataContainer : ScriptableObject
{
    [EnumNamedArray(typeof(SettlementType))]
    public List<SettlementData> data = new();
}
