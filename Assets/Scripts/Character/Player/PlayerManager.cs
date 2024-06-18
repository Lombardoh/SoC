public class PlayerManager : CharacterManager
{
    protected override void Awake()
    {
        base.Awake();
        CharacterLocomotionManager = GetComponent<PlayerLocomotionManager>();
    }

    protected override void LateUpdate()
    {
        PlayerCamera.Instance.HandleAllCameraActions();
    }

}