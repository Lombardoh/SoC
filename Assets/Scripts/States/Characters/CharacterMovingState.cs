using UnityEngine;

public class CharacterMovingState : CharacterBaseState
{
    public override void OnEnter(CharacterStateManager character)
    {
    }
    
    public override void OnExit(CharacterStateManager character)
    {
        character.player.playerAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
    }

    public override void Update(CharacterStateManager character)
    {
        character.player.playerAnimatorManager.UpdateAnimatorMovementParameter(0, 1);
        if (PlayerInputManager.instance.moveAmount == 0)
        {
            character.SwitchState(character.idleState);
        }        
        if (PlayerInputManager.instance.isAttacking == true)
        {
            character.SwitchState(character.attackingState);
        }
    }
}
