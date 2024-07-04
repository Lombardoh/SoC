public class CharacterWalkingState : CharacterBaseState
{
    public override void OnEnter(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorMovementParameter(true);
    }
    
    public override void OnExit(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
    }

    public override void Update(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorMovementParameter(true);
    }
}
