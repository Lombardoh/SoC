using UnityEngine;
using System.Collections;
public class CharacterHurtState : CharacterBaseState
{
    public override void OnEnter(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorWasHurtParameter(true);
        _IUnitManager.Transform.GetComponent<MonoBehaviour>().StartCoroutine(HurtRecovery(_IUnitManager, 1f));
    }
    public override void OnExit(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorWasHurtParameter(false);
    }

    public override void Update(IUnitManager _IUnitManager)
    {

    }
    private IEnumerator HurtRecovery(IUnitManager _IUnitManager, float delay)
    {
        yield return new WaitForSeconds(delay);
        _IUnitManager.Transform.TryGetComponent<IDamageable>(out var damageable);
        if (damageable == null) yield return null;
        _IUnitManager.CharacterStateManager.OnStateChangeRequested(CharacterState.Attacking);
    }
}
