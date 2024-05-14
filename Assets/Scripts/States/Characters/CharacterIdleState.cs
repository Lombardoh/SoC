using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public override void OnEnter(CharacterStateManager character)
    {
        character.player.playerAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
    }
    public override void OnExit(CharacterStateManager character)
    {
    }

    public override void Update(CharacterStateManager character)
    {
        if (PlayerInputManager.instance.moveAmount > 0)
        {
            character.SwitchState(character.movingState);
        }
        if(PlayerInputManager.instance.isAttacking == true)
        {
            character.SwitchState(character.attackingState);
        }
    }
}
