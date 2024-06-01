using UnityEngine;

public class CharacterHurtState : CharacterBaseState
{
    public override void OnEnter(CharacterManager character)
    {
        Debug.Log("enter");
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
        character.characterAnimatorManager.UpdateAnimatorWasHurtParameter(true);
    }
    public override void OnExit(CharacterManager character)
    {
        Debug.Log("exit");
        character.characterAnimatorManager.UpdateAnimatorWasHurtParameter(false);
    }

    public override void Update(CharacterManager character)
    {

    }
}
