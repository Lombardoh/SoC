using System.Collections;
using UnityEngine;

public class CharacterAttackingState : CharacterBaseState
{
    INPCManager _NPCManager;
    IDamageable target;
    public override void OnEnter(ICharacterManager character)
    {
        _NPCManager = character.Transform.GetComponent<INPCManager>();
        target = character.Target.GetComponent<IDamageable>();
        float randomNumber = Random.Range(1, 5);
        character.LockedInAnimation = true;
        character.Transform.GetComponent<MonoBehaviour>().StartCoroutine(InvokeAttack(character, randomNumber));
    }

    public override void OnExit(ICharacterManager character)
    {

    }

    public override void Update(ICharacterManager character)
    {
        character.CharacterLocomotionManager.LookAtTarget();
    }

    private IEnumerator InvokeAttack(ICharacterManager character, float delay)
    {
        yield return new WaitForSeconds(delay);
        Attack(character);
    }

    private void Attack(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorAttackParameter(true);
        character.AttackHitBox.gameObject.SetActive(true);
    }

    private void KeepFigthing(ICharacterManager character)
    {
        if (target == null) { character.CharacterStateManager.OnStateChangeRequested(CharacterState.Idle); return; }
        character.CharacterStateManager.OnStateChangeRequested(CharacterState.Fighting); 
        return;
    }
}
