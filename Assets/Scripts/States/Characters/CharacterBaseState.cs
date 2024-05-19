using UnityEngine;

public abstract class CharacterBaseState
{
    public abstract void OnEnter(CharacterManager character);
    public abstract void OnExit(CharacterManager character);
    public abstract void Update(CharacterManager character);

    public virtual void ToState(CharacterManager character, CharacterBaseState state)
    {
        character.characterStateManager.CurrentState.OnExit(character);
        character.characterStateManager.CurrentState = state;
        character.characterStateManager.CurrentState.OnEnter(character);
    }
}
