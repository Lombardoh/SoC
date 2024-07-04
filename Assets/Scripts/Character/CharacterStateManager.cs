using UnityEngine;
public class CharacterStateManager : MonoBehaviour
{
    public IUnitManager _IUnitManager;
    public INPCManager _NPCManager;
    public  CharacterBaseState CurrentState { get; set; }
    public string currentStateString = string.Empty;
    public CharacterState CurrentStateType { get; set; }
    private void Awake()
    {
        _IUnitManager = GetComponent<IUnitManager>();
        _NPCManager = GetComponent<INPCManager>();
    }

    void Update()
    {
        if (_IUnitManager == null) return;
        if (CurrentState == null) { OnStateChangeRequested(CharacterState.Idle); }
        CurrentState.Update(_IUnitManager);
    }

    public void OnStateChangeRequested(CharacterState newState)
    {
        currentStateString = newState.ToString();
        CurrentStateType = newState;

        CurrentState ??= StateFactory.CreateState(CharacterState.Idle);
        CurrentState.OnExit(_IUnitManager);
        CurrentState = StateFactory.CreateState(newState);
        CurrentState.OnEnter(_IUnitManager);
    }

    public void OnSelectNextState(UnitTaskType task)
    {
        switch (task)
        {
            case UnitTaskType.Idling:
                OnStateChangeRequested(CharacterState.Idle);
                break;            
            case UnitTaskType.GoingToGather:
                _IUnitManager.Target = ResourceUtils.FindClosestResource(transform, _NPCManager.AssignedResource);
                _NPCManager.NextAssignedTask = UnitTaskType.Gathering;
                OnStateChangeRequested(CharacterState.Following);
                break;
            case UnitTaskType.Gathering:
                OnStateChangeRequested(CharacterState.Working);
                break;
            case UnitTaskType.GoingToDeposit:
                _IUnitManager.Target = UnitUtils.FindClosestTarget(transform, TagType.City);
                _NPCManager.NextAssignedTask = UnitTaskType.Depositing;
                OnStateChangeRequested(CharacterState.Following);
                break;           
            case UnitTaskType.Depositing:
                OnStateChangeRequested(CharacterState.Depositing);
                break;
            case UnitTaskType.Wandering:
                if (_IUnitManager.Target == null)
                {
                    GameObject assignedTarget = new(_IUnitManager + " AssignedTarget");
                    assignedTarget.transform.position = GameUtils.GetRandomPosition(_IUnitManager.Transform.position, 10f, 15f);
                    _IUnitManager.Target = assignedTarget;
                }
                OnStateChangeRequested(CharacterState.Idle);
                Invoke(nameof(ChangeToFollowingState), 3f); ;
                break;            
            case UnitTaskType.Hunting:
                _NPCManager.AssignedTask = UnitTaskType.Hunting;
                _NPCManager.NextAssignedTask = UnitTaskType.Attacking;
                OnStateChangeRequested(CharacterState.Following);
                break;  
            case UnitTaskType.Attacking:
                _NPCManager.NextAssignedTask = UnitTaskType.Attacking;
                OnStateChangeRequested(CharacterState.Attacking);
                break;            
        }
    }

    private void ChangeToFollowingState()
    {
        _IUnitManager.Target.transform.position = GameUtils.GetRandomPosition(transform.position, 10f, 15f);
        OnStateChangeRequested(CharacterState.Following);
    }

    public void AttackJustFinished()
    {
        _IUnitManager.Target.TryGetComponent<IDamageable>(out IDamageable damageable);
        if (damageable != null) 
        {
            OnStateChangeRequested(CharacterState.Attacking);
            return;
        }
        OnStateChangeRequested(CharacterState.Idle);
    }
}
