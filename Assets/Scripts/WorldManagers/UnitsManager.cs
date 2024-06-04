using System.Collections.Generic;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    public GameObject unitPrefab;
    public GameObject spawnGame;

    private List<GameObject> units = new();

    private void Start()
    {
        GameObject unit = Instantiate(unitPrefab);
        unit.transform.position = spawnGame.transform.position;
        units.Add(unit);
    }
}
