using UnityEngine;
public class CharacterWorkingState : CharacterBaseState
{
    private INPCManager _NPCManager;
    public override void OnEnter(IUnitManager _IUnitManager)
    {
        _NPCManager = _IUnitManager as INPCManager;
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorWorkingParameter(true);
        if (_IUnitManager is ITickListener tickListener)
        {
            tickListener.SubscribeToTicks(TickTime.Large);
        }
        _NPCManager.NextAssignedTask = UnitTaskType.GoingToDeposit;

        //if (character.Target.TryGetComponent<ITickListener>(out var target))
        //{
        //    target.SubscribeToTicks(TickTime.Large);
        //}
    }
    
    public override void OnExit(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorWorkingParameter(false);
        if (_IUnitManager is ITickListener tickListener)
        {
            tickListener.UnsubscribeToTicks(TickTime.Large);
        }
    }

    public override void Update(IUnitManager _IUnitManager)
    {

    }
}
