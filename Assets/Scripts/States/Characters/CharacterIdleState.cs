public class CharacterIdleState : CharacterBaseState
{
    public override void OnEnter(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
    }
    public override void OnExit(ICharacterManager character)
    {
    }

    public override void Update(ICharacterManager character)
    {
    }
}
