using UnityEngine;

public class CharacterHurtState : CharacterBaseState
{
    public override void OnEnter(CharacterManager character)
    {

        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
        character.characterAnimatorManager.UpdateAnimatorWasHurtParameter(true);
    }
    public override void OnExit(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorWasHurtParameter(false);
    }

    public override void Update(CharacterManager character)
    {

    }
}
