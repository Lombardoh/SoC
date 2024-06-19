public abstract class CharacterBaseState
{
    public abstract void OnEnter(ICharacterManager character);
    public abstract void OnExit(ICharacterManager character);
    public abstract void Update(ICharacterManager character);
}
