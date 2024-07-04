using UnityEngine;

public class CharacterDepositingState : CharacterBaseState
{
    private UnitManager unitManager;
    private INPCManager _NPCManager;
    public override void OnEnter(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorWorkingParameter(true);

        unitManager = _IUnitManager as UnitManager;
        _NPCManager = _IUnitManager as INPCManager;
        IDepositable depositable = _IUnitManager.Target.GetComponent<IDepositable>();

        depositable.Deposite(_NPCManager.AssignedResource, unitManager.GetResourceAmount());
        unitManager.EmptyResource();

        _NPCManager.NextAssignedTask = UnitTaskType.GoingToGather;
        _IUnitManager.CharacterStateManager.OnSelectNextState(_NPCManager.NextAssignedTask);
    }
    
    public override void OnExit(IUnitManager _IUnitManager)
    {
    }

    public override void Update(IUnitManager _IUnitManager)
    {

    }
}
