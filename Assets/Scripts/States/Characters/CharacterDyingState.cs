using UnityEngine;

public class CharacterDyingState : CharacterBaseState
{
    IDamageable damageable;
    public override void OnEnter(IUnitManager _IUnitManager)
    {
        damageable = _IUnitManager.Transform.GetComponent<IDamageable>();
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorIsDyingParameter(true);
        _IUnitManager.Transform.GetComponent<MonoBehaviour>().Invoke(nameof(Dispose), 5f);
    }

    public override void OnExit(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorIsDyingParameter(false);
    }

    public override void Update(IUnitManager _IUnitManager)
    {
    }

    private void Dispose()
    {
        damageable.Dispose();
    }
}
