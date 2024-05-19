public class CharacterMovingState : CharacterBaseState
{
    public override void OnEnter(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 1);
    }
    
    public override void OnExit(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
    }

    public override void Update(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 1);
    }
}
