using UnityEngine;

public class StationManager : MonoBehaviour
{
    private Station station;

    private void Awake()
    {
        station = new(ResourceType.Rock, 20);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;

        if (other.TryGetComponent<IWorkable>(out var characterManager))
        {
            characterManager.StartWorking(station.resourceType);
        }
    }
}
