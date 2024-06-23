using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    public ICharacterManager characterManager;
    public  CharacterBaseState CurrentState { get; set; }
    public string currentStateString = string.Empty;
    public CharacterState CurrentStateType { get; set; }

    private void Awake()
    {
        characterManager = GetComponent<ICharacterManager>();
    }

    void Update()
    {
        if (characterManager == null) return;
        CurrentState.Update(characterManager);
    }

    public void OnStateChangeRequested(CharacterState newState)
    {
        currentStateString = newState.ToString();
        CurrentStateType = newState;

        CurrentState ??= StateFactory.CreateState(CharacterState.Idle);
        CurrentState.OnExit(characterManager);
        CurrentState = StateFactory.CreateState(newState);
        CurrentState.OnEnter(characterManager);
    }

    public void OnSelectNextState(UnitTaskType task)
    {
        switch (task)
        {
            case UnitTaskType.Idling:
                OnStateChangeRequested(CharacterState.Idle);
                break;            
            case UnitTaskType.Gathering:
                OnStateChangeRequested(CharacterState.Working);
                break;
            case UnitTaskType.Depositing:
                NPCManager GetNPCManager = characterManager as NPCManager;
                characterManager.Target = UnitUtils.FindClosestTarget(characterManager.Transform, TagType.City);
                characterManager.TargetPosition = characterManager.Target.transform.position;
                OnStateChangeRequested(CharacterState.Following);
                break;
            case UnitTaskType.Wandering:
                OnStateChangeRequested(CharacterState.Idle);
                characterManager.TargetPosition = GameUtils.GetRandomPosition(characterManager.Transform.position, 10f);
                Invoke(nameof(ChangeToFollowingState), 2f); ;
                break;
        }
    }

    private void ChangeToFollowingState()
    {
        OnStateChangeRequested(CharacterState.Following);
    }
}
