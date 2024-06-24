using UnityEngine;

public class TemporalTarget : MonoBehaviour, ITemporal
{
    public void Dispose()
    {
        Destroy(gameObject);
    }
}
