using UnityEngine;

public class CharacterAttackingState : CharacterBaseState
{
    float duration;
    float startTime;
    public override void OnEnter(CharacterManager character)
    {
        duration = character.characterAnimatorManager.animator.GetCurrentAnimatorStateInfo(1).length;
        character.characterAnimatorManager.UpdateAnimatorAttackParameter(true);
        startTime = Time.time;
    }

    public override void OnExit(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorAttackParameter(false);
        InputEvents.OnSetIdle?.Invoke();
    }

    public override void Update(CharacterManager character)
    {
        if (Time.time - startTime > duration)
        {
            character.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Idle);
        }
    }
}
