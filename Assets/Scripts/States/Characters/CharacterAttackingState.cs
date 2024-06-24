public class CharacterAttackingState : CharacterBaseState
{
    INPCManager _NPCManager;
    IDamageable target;
    public override void OnEnter(ICharacterManager character)
    {
        _NPCManager = character.Transform.GetComponent<INPCManager>();
        target = character.Target.GetComponent<IDamageable>();
    }

    public override void OnExit(ICharacterManager character)
    {

    }

    public override void Update(ICharacterManager character)
    {
        if (character.Target == null)
        {
            _NPCManager.NextAssignedTask = UnitTaskType.Wandering;
            character.CharacterStateManager.OnSelectNextState(_NPCManager.NextAssignedTask);
            return;
        }
        target.Die();
        character.Target = null;
    }
}
