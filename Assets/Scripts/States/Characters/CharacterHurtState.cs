public class CharacterHurtState : CharacterBaseState
{
    public override void OnEnter(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
    }
    public override void OnExit(CharacterManager character)
    {
    }

    public override void Update(CharacterManager character)
    {

    }
}
