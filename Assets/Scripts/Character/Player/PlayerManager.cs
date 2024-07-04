public class PlayerManager : UnitManager
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