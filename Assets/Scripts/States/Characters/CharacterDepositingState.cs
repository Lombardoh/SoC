using UnityEngine;

public class CharacterDepositingState : CharacterBaseState
{
    private CharacterManager characterManager;
    private INPCManager NPCManager;
    public override void OnEnter(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
        characterManager = character as CharacterManager;
        NPCManager = character as INPCManager;
        IDepositable depositable = characterManager.Target.GetComponent<IDepositable>();
        depositable.Deposite(NPCManager.AssignedResource, characterManager.GetResourceAmount());
        characterManager.EmptyResource();
        character.CharacterStateManager.OnStateChangeRequested(CharacterState.Following);
        NPCManager.UnitActionType = UnitActionType.Gathering;
    }
    
    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorWorkingParameter(false);
        character.Target = ResourceUtils.FindClosestResource(character.Transform, ResourceType.Wood);
    }

    public override void Update(ICharacterManager character)
    {

    }
}
