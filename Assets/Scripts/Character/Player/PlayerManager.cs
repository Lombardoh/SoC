public class PlayerManager : CharacterManager
{
    protected override void Awake()
    {
        base.Awake();
        characterLocomotionManager = GetComponent<PlayerLocomotionManager>();
    }

    protected override void Update()
    {
        characterLocomotionManager.HandleAllMovement();
    }

    protected override void LateUpdate()
    {
        PlayerCamera.Instance.HandleAllCameraActions();
    }

}