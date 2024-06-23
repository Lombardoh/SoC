using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterStateManager : MonoBehaviour
{
    public ICharacterManager characterManager;
    public INPCManager _NPCManager;
    public  CharacterBaseState CurrentState { get; set; }
    public string currentStateString = string.Empty;
    public CharacterState CurrentStateType { get; set; }
    private void Awake()
    {
        characterManager = GetComponent<ICharacterManager>();
        _NPCManager = GetComponent<INPCManager>();
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
            case UnitTaskType.GoingToGather:
                characterManager.Target = ResourceUtils.FindClosestResource(transform, _NPCManager.AssignedResource);
                _NPCManager.NextAssignedTask = UnitTaskType.Gathering;
                OnStateChangeRequested(CharacterState.Following);
                break;
            case UnitTaskType.Gathering:
                OnStateChangeRequested(CharacterState.Working);
                break;
            case UnitTaskType.GoingToDeposit:
                characterManager.Target = UnitUtils.FindClosestTarget(transform, TagType.City);
                _NPCManager.NextAssignedTask = UnitTaskType.Depositing;
                OnStateChangeRequested(CharacterState.Following);
                break;           
            case UnitTaskType.Depositing:
                OnStateChangeRequested(CharacterState.Depositing);
                break;
            case UnitTaskType.Wandering:
                OnStateChangeRequested(CharacterState.Idle);
                Invoke(nameof(ChangeToFollowingState), 3f); ;
                break;
        }
    }

    private void ChangeToFollowingState()
    {
        characterManager.Target.transform.position = GameUtils.GetRandomPosition(transform.position, 10f, 15f);
        OnStateChangeRequested(CharacterState.Following);
    }
}
