using UnityEngine;

public class CharacterDyingState : CharacterBaseState
{
    IDamageable damageable;
    public override void OnEnter(ICharacterManager character)
    {
        damageable = character.Transform.GetComponent<IDamageable>();
        character.CharacterAnimatorManager.UpdateAnimatorIsDyingParameter(true);
        character.Transform.GetComponent<MonoBehaviour>().Invoke(nameof(Dispose), 2f);
    }

    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorIsDyingParameter(false);
    }

    public override void Update(ICharacterManager character)
    {
    }

    private void Dispose()
    {
        damageable.Dispose();
    }
}
