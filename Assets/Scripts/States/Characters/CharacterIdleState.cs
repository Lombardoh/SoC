public class CharacterIdleState : CharacterBaseState
{
    public override void OnEnter(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
    }
    public override void OnExit(IUnitManager _IUnitManager)
    {
    }

    public override void Update(IUnitManager _IUnitManager)
    {
    }
}
