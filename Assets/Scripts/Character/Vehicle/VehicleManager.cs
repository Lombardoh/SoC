using Unity.VisualScripting;
using UnityEngine;

public class VehicleManager : CharacterManager, IParentInteractable
{

    protected override void Start()
    {
        base.Start();
    }
    public void OnInteract()
    {
        PlayerInputManager.instance.player.gameObject.SetActive(false);
        PlayerInputManager.instance.player = this;
        this.enabled = true;
        PlayerCamera.Instance.player = this;
        CharacterLocomotionManager.enabled = true;
    }
}
