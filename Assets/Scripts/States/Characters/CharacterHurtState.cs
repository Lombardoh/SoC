using UnityEngine;

public class CharacterHurtState : CharacterBaseState
{
    public override void OnEnter(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
        character.CharacterAnimatorManager.UpdateAnimatorWasHurtParameter(true);
    }
    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorWasHurtParameter(false);
    }

    public override void Update(ICharacterManager character)
    {

    }
}
