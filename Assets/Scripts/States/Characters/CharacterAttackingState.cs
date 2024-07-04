using System.Collections;
using UnityEngine;

public class CharacterAttackingState : CharacterBaseState
{
    INPCManager _NPCManager;
    IDamageable target;
    private Coroutine attackCoroutine;

    public override void OnEnter(ICharacterManager character)
    {
        _NPCManager = character.Transform.GetComponent<INPCManager>();
        target = character.Target.GetComponent<IDamageable>();
        float randomNumber = Random.Range(1, 20);
        character.LockedInAnimation = true;
        attackCoroutine = character.Transform.GetComponent<MonoBehaviour>().StartCoroutine(InvokeAttack(character, randomNumber));
    }

    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorAttackParameter(false);
        character.AttackHitBox.gameObject.SetActive(false);
        if (attackCoroutine == null) return;
        
        character.Transform.GetComponent<MonoBehaviour>().StopCoroutine(attackCoroutine);
        attackCoroutine = null;
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
}
