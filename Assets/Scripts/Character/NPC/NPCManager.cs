public class NPCManager : CharacterManager
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        characterStateManager.OnStateChangeRequested(CharacterStateEnum.Idle);
    }
}
