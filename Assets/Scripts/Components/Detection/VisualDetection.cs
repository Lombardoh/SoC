using UnityEngine;

public class VisualDetection : MonoBehaviour
{
    public CharacterManager CharacterManager {  get; private set; }
    public INPCManager INPCManager { get; private set; }
    void Start()
    {
        CharacterManager = transform.parent.GetComponent<CharacterManager>();
        INPCManager = transform.parent.GetComponent<INPCManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterManager.Target.TryGetComponent<ITemporal>(out ITemporal oldTarget);
        if (oldTarget != null)
        {
            oldTarget.Dispose();
        }
        CharacterManager.Target = other.transform.gameObject;
        INPCManager.NextAssignedTask = UnitTaskType.Hunting;
        CharacterManager.CharacterStateManager.OnSelectNextState(INPCManager.NextAssignedTask);
    }
}
