public class CharacterJumpingState : CharacterBaseState
{
    public override void OnEnter(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorGroundingParameter(false);
    }

    public override void OnExit(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorGroundingParameter(true);
    }

    public override void Update(IUnitManager _IUnitManager)
    {
    }
}
