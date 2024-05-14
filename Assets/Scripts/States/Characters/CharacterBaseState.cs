using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class CharacterBaseState
{
    public abstract void OnEnter(CharacterStateManager character);
    public abstract void OnExit(CharacterStateManager character);
    public abstract void Update(CharacterStateManager character);

    public virtual void ToState(CharacterStateManager character, CharacterBaseState state)
    {
        character.currentState.OnExit(character);
        character.currentState = state;
        character.currentState.OnEnter(character);
    }
}
