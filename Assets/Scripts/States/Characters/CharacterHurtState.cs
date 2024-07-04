using UnityEngine;
using System.Collections;
public class CharacterHurtState : CharacterBaseState
{
    public override void OnEnter(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
        character.CharacterAnimatorManager.UpdateAnimatorWasHurtParameter(true);
        character.Transform.GetComponent<MonoBehaviour>().StartCoroutine(HurtRecovery(character, 1f));
    }
    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorWasHurtParameter(false);
    }

    public override void Update(ICharacterManager character)
    {

    }
    private IEnumerator HurtRecovery(ICharacterManager character, float delay)
    {
        yield return new WaitForSeconds(delay);
        character.Transform.TryGetComponent<IDamageable>(out var damageable);
        if (damageable == null) yield return null;
        character.CharacterStateManager.OnStateChangeRequested(CharacterState.Attacking);
    }
}
