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
        if (CharacterManager.Target != null)
        {
            CharacterManager.Target.TryGetComponent<ITemporal>(out ITemporal oldTarget);
            oldTarget?.Dispose();
        }

        CharacterManager.Target = other.transform.gameObject;
        CharacterManager.Target.TryGetComponent<ICombatable>(out ICombatable fighter);
        if (fighter != null) { CharacterManager.StartCombat(); }
    }
}
