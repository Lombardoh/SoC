public abstract class CharacterBaseState
{
    public abstract void OnEnter(ICharacterManager character);
    public abstract void OnExit(ICharacterManager character);
    public abstract void Update(ICharacterManager character);

    public virtual void ToState(ICharacterManager character, CharacterBaseState state)
    {
        character.CharacterStateManager.CurrentState.OnExit(character);
        character.CharacterStateManager.CurrentState = state;
        character.CharacterStateManager.CurrentState.OnEnter(character);
    }
}
