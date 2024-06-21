using System.Collections.Generic;
using UnityEngine;

public class CityUnitsManager : MonoBehaviour
{
    public GameObject unitPrefab;
    public Transform spawnTransform;

    private readonly List<NPCManager> units = new();

    private void OnEnable()
    {
        ResourceEvents.OnUpdatePopulation+= UpdatePopulation;
    }

    private void OnDisable()
    {
        ResourceEvents.OnUpdatePopulation -= UpdatePopulation;
    }
    private void UpdatePopulation(int amount)
    {
        NPCManager unit = CreateUnit();
        ResourceEvents.OnGetLowestResource((res) => unit.FindWork(res));
    }
    private NPCManager CreateUnit()
    {
        int population = 0; 
        UnitEvents.OnCheckPopulation((res) => population = res);
        if (units.Count >= population) { return null; }

        GameObject unit = Instantiate(unitPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        unit.transform.position = spawnTransform.position;
        NPCManager NPC = unit.GetComponent<NPCManager>();
        units.Add(NPC);
        return NPC;
    }
}
