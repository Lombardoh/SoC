public class CharacterJumpingState : CharacterBaseState
{
    public override void OnEnter(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorGroundingParameter(false);
    }

    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorGroundingParameter(true);
    }

    public override void Update(ICharacterManager character)
    {
    }
}
