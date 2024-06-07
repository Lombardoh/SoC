using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    public GameObject unitPrefab;
    public Transform spawnTransform;

    private List<GameObject> units = new();

    private void OnEnable()
    {
        UnitEvents.OnRequestUnit += HandleRequestUnit;
    }

    private void OnDisable()
    {
        UnitEvents.OnRequestUnit -= HandleRequestUnit;
    }

    private void HandleRequestUnit(Action<CharacterManager> callback)
    {
        CharacterManager unit = CreateUnit();
        callback?.Invoke(unit);
    }
    public CharacterManager CreateUnit()
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
