using UnityEngine;

public class CharacterJumpingState : CharacterBaseState
{
    public override void OnEnter(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorGroundingParameter(false);
        character.characterLocomotionManager.AttempToPerformJump();
    }

    public override void OnExit(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorGroundingParameter(true);
    }

    public override void Update(CharacterManager character)
    {
    }
}
