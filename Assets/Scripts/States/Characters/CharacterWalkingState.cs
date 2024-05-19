public class CharacterWalkingState : CharacterBaseState
{
    public override void OnEnter(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
    }
    
    public override void OnExit(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
    }

    public override void Update(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
    }
}
