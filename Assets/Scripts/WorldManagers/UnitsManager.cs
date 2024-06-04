using System.Collections.Generic;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    public GameObject unitPrefab;
    public GameObject spawnGame;

    private List<GameObject> units = new();

    private void Start()
    {
        GameObject unit = Instantiate(unitPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        unit.transform.position = spawnGame.transform.position;
        CharacterManager character = unit.GetComponent<CharacterManager>();
        character.target = spawnGame.transform;
        units.Add(unit);
        character.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Following);
    }
}
