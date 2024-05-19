public class CharacterAttackingState : CharacterBaseState
{
    public override void OnEnter(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorAttackParameter(true);
    }

    public override void OnExit(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorAttackParameter(false);
        InputEvents.OnSetIdle?.Invoke();
    }

    public override void Update(CharacterManager character)
    {

    }
}
