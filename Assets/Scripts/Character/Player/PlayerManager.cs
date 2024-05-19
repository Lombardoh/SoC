public class PlayerManager : CharacterManager
{
    public PlayerLocomotionManager playerLocomotionManager;

    protected override void Awake()
    {
        base.Awake();
        playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
    }

    protected override void Update()
    {
        playerLocomotionManager.HandleAllMovement();
    }

    protected override void LateUpdate()
    {
        PlayerCamera.Instance.HandleAllCameraActions();
    }

}