using UnityEngine;

public class VisualDetection : MonoBehaviour
{
    public UnitManager UnitManager {  get; private set; }
    public INPCManager INPCManager { get; private set; }
    void Start()
    {
        UnitManager = transform.parent.GetComponent<UnitManager>();
        INPCManager = transform.parent.GetComponent<INPCManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (UnitManager.Target != null)
        {
            UnitManager.Target.TryGetComponent<ITemporal>(out ITemporal oldTarget);
            oldTarget?.Dispose();
        }

        UnitManager.Target = other.transform.gameObject;
        UnitManager.Target.TryGetComponent<ICombatable>(out ICombatable fighter);
        if (fighter != null) { UnitManager.StartCombat(); }
    }
}
