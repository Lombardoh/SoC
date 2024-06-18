using System.Collections.Generic;
using UnityEngine;

public class CityUnitsManager : MonoBehaviour
{
    public GameObject unitPrefab;
    public Transform spawnTransform;

    private readonly List<GameObject> units = new();

    private void OnEnable()
    {
        ResourceEvents.OnUpdatePopulation+= updatePopulation;
    }

    private void OnDisable()
    {
        ResourceEvents.OnUpdatePopulation -= updatePopulation;
    }

    private void updatePopulation(int amount)
    {
        CharacterManager unit = CreateUnit();
    }
    private CharacterManager CreateUnit()
    {
        int population = 0; 
        UnitEvents.OnCheckPopulation((res) => population = res);
        if (units.Count >= population) { return null; }

        GameObject unit = Instantiate(unitPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        unit.transform.position = spawnTransform.position;
        CharacterManager character = unit.GetComponent<CharacterManager>();
        units.Add(unit);
        return character;
    }
}
