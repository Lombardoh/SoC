using System.Collections;
using UnityEngine;

public class CharacterAttackingState : CharacterBaseState
{
    INPCManager _NPCManager;
    IDamageable target;
    private Coroutine attackCoroutine;

    public override void OnEnter(IUnitManager _IUnitManager)
    {
        _NPCManager = _IUnitManager.Transform.GetComponent<INPCManager>();
        target = _IUnitManager.Target.GetComponent<IDamageable>();
        float randomNumber = Random.Range(1, 20);
        _IUnitManager.LockedInAnimation = true;
        attackCoroutine = _IUnitManager.Transform.GetComponent<MonoBehaviour>().StartCoroutine(InvokeAttack(_IUnitManager, randomNumber));
    }

    public override void OnExit(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorAttackParameter(false);
        _IUnitManager.AttackHitBox.gameObject.SetActive(false);
        if (attackCoroutine == null) return;

        _IUnitManager.Transform.GetComponent<MonoBehaviour>().StopCoroutine(attackCoroutine);
        attackCoroutine = null;
    }

    public override void Update(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterLocomotionManager.LookAtTarget();
    }

    private IEnumerator InvokeAttack(IUnitManager _IUnitManager, float delay)
    {
        yield return new WaitForSeconds(delay);
        Attack(_IUnitManager);
    }

    private void Attack(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorAttackParameter(true);
        _IUnitManager.AttackHitBox.gameObject.SetActive(true);
    }
}
