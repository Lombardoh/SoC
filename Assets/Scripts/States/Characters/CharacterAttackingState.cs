using UnityEngine;

public class CharacterAttackingState : CharacterBaseState
{
    float duration;
    float startTime;
    public override void OnEnter(ICharacterManager character)
    {
        duration = character.CharacterAnimatorManager.animator.GetCurrentAnimatorStateInfo(1).length;
        character.CharacterAnimatorManager.UpdateAnimatorAttackParameter(true);
        startTime = Time.time;
    }

    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorAttackParameter(false);
        InputEvents.OnSetIdle?.Invoke();
    }

    public override void Update(ICharacterManager character)
    {
        if (Time.time - startTime > duration)
        {
            character.CharacterStateManager.OnStateChangeRequested(CharacterState.Idle);
        }
    }
}
