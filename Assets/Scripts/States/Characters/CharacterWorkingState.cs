using UnityEngine;
public class CharacterWorkingState : CharacterBaseState
{
    private INPCManager _NPCManager;
    public override void OnEnter(ICharacterManager character)
    {
        _NPCManager = character as INPCManager;
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
        character.CharacterAnimatorManager.UpdateAnimatorWorkingParameter(true);
        if (character is ITickListener tickListener)
        {
            tickListener.SubscribeToTicks(TickTime.Large);
        }
        _NPCManager.NextAssignedTask = UnitTaskType.GoingToDeposit;

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
    }

    public override void Update(ICharacterManager character)
    {

    }
}
