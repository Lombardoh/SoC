using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class SettlementUnitsManager : MonoBehaviour
{
    public GameObject unitPrefab;
    public Transform spawnTransform;
    protected SettlementUIResourceManager resourceUIManager;
    protected SettlementManager settlementManager;

    private void Awake()
    {
        resourceUIManager = GetComponent<SettlementUIResourceManager>();
        settlementManager = GetComponent<SettlementManager>();
    }

    private readonly List<NPCManager> units = new();

    public NPCManager CreateUnit()
    {
        if (units.Count >= settlementManager.GetResourceAmount(ResourceType.Population)) { return null; }

        GameObject unit = Instantiate(unitPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        unit.transform.position = spawnTransform.position;
        NPCManager NPC = unit.GetComponent<NPCManager>();
        resourceUIManager.UpdateResources();
        units.Add(NPC);
        return NPC;
    }
}
