public class CharacterWorkingState : CharacterBaseState
{
    public override void OnEnter(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
        character.characterAnimatorManager.UpdateAnimatorWorkingParameter(true);

        character.SubscribeToTicks(TickTime.Large);
        if (character.target.TryGetComponent<ITickListener>(out var target))
        {
            target.SubscribeToTicks(TickTime.Large);
        }


    }
    
    public override void OnExit(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorWorkingParameter(false);
        character.UnsubscribeToTicks(TickTime.Large);
        if (character.target.TryGetComponent<ITickListener>(out var target))
        {
            target.UnsubscribeToTicks(TickTime.Large);
        }

    }

    public override void Update(CharacterManager character)
    {

    }
}
