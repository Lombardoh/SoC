using UnityEngine;

public class CharacterDepositingState : CharacterBaseState
{
    private CharacterManager characterManager;
    private INPCManager _NPCManager;
    public override void OnEnter(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
        character.CharacterAnimatorManager.UpdateAnimatorWorkingParameter(true);
        characterManager = character as CharacterManager;
        _NPCManager = character as INPCManager;
        IDepositable depositable = characterManager.Target.GetComponent<IDepositable>();
        depositable.Deposite(_NPCManager.AssignedResource, characterManager.GetResourceAmount());
        characterManager.EmptyResource();
        _NPCManager.NextAssignedTask = UnitTaskType.GoingToGather;
        character.CharacterStateManager.OnSelectNextState(_NPCManager.NextAssignedTask);
    }
    
    public override void OnExit(ICharacterManager character)
    {
    }

    public override void Update(ICharacterManager character)
    {

    }
}
