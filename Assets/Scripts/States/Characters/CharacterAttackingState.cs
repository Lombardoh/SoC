using UnityEngine;
using UnityEngine.Events;

public class CharacterAttackingState : CharacterBaseState
{
    public UnityEvent onAnimationEndEvent;
    public override void OnEnter(CharacterStateManager character)
    {
        character.player.playerAnimatorManager.UpdateAnimatorAttackParameter(true);
    }

    public override void OnExit(CharacterStateManager character)
    {
        character.player.playerAnimatorManager.UpdateAnimatorAttackParameter(false);
    }

    public override void Update(CharacterStateManager character)
    {
        if (PlayerInputManager.instance.isAttacking == false)
        {
            character.SwitchState(character.idleState);
        }
    }

}
