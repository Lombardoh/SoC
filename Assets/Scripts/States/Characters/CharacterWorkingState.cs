using UnityEngine;

public class CharacterWorkingState : CharacterBaseState
{
    private INPCManager characterManager;
    public override void OnEnter(ICharacterManager character)
    {
        characterManager = character as INPCManager;
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
        character.CharacterAnimatorManager.UpdateAnimatorWorkingParameter(true);

        if (character is ITickListener tickListener)
        {
            tickListener.SubscribeToTicks(TickTime.Large);
        }

        //if (character.Target.TryGetComponent<ITickListener>(out var target))
        //{
        //    target.SubscribeToTicks(TickTime.Large);
        //}
    }
    
    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorWorkingParameter(false);
        if (character is ITickListener tickListener)
        {
            tickListener.UnsubscribeToTicks(TickTime.Large);
        }
        //if (character.Target.TryGetComponent<ITickListener>(out var target))
        //{
        //    target.UnsubscribeToTicks(TickTime.Large);
        //}

        character.Target = UnitUtils.FindClosestTarget(character.Transform, TagType.City);
        characterManager.UnitActionType = UnitActionType.Depositing;
    }

    public override void Update(ICharacterManager character)
    {

    }
}
