using UnityEngine;

public class CharacterFollowState : CharacterBaseState
{
    public override void OnEnter(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
    }

    public override void OnExit(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
    }

    public override void Update(CharacterManager character)
    {
        character.characterController.Move(Time.deltaTime * 5f * character.transform.forward);
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
        
        if (Vector3.Distance(character.target.position, character.transform.position) < 1)
        {
            character.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Attacking);
        }
    }
}
