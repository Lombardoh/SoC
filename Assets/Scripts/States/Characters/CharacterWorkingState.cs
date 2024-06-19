public class CharacterWorkingState : CharacterBaseState
{
    public override void OnEnter(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);        
        //character.TickListener.SubscribeToTicks(TickTime.Large);
        //if (character.target.TryGetComponent<ITickListener>(out var target))
        //{
        //    target.SubscribeToTicks(TickTime.Large);
        //}
    }
    
    public override void OnExit(ICharacterManager character)
    {
        //character.CharacterAnimatorManager.UpdateAnimatorWorkingParameter(false);
        //character.TickListener.UnsubscribeToTicks();
        //if (character.target.TryGetComponent<ITickListener>(out var target))
        //{
        //    target.UnsubscribeToTicks();
        //}

        //character.target = UnitUtils.FindClosestTarget(character.transform, TagType.City);
    }

    public override void Update(ICharacterManager character)
    {

    }
}
