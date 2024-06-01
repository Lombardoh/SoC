using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    private CharacterManager characterManager;

    public string currentStateString = string.Empty;
    private CharacterStateEnum currentStateType = CharacterStateEnum.Idle;

    private CharacterBaseState currentState;
    private readonly CharacterIdleState idleState = new();
    private readonly CharacterWalkingState walkingState = new();
    private readonly CharacterRunningState runningState = new();
    private readonly CharacterHurtState hurtState = new();
    private readonly CharacterAttackingState attackingState = new();
    private readonly CharacterJumpingState jumpingState = new();
    private readonly CharacterFollowState followState = new();

    public CharacterBaseState CurrentState
    {
        get { return currentState; }
        set { currentState = value; }
    }    
    public CharacterStateEnum CurrentStateType
    {
        get { return currentStateType; }
        set { currentStateType = value; }
    }

    private void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
        currentState = idleState;
    }

    private void Start()
    {
        currentState.OnEnter(characterManager);
    }

    void Update()
    {
        currentState.Update(characterManager);
    }

    public void OnStateChangeRequested(CharacterStateEnum newState)
    {
        currentStateString = newState.ToString();
        CurrentStateType = newState;
        switch (newState)
        {
            case CharacterStateEnum.Idle:
                SwitchState(idleState);
                break;
            case CharacterStateEnum.Hurt:
                SwitchState(hurtState);
                break;
            case CharacterStateEnum.Attacking:
                SwitchState(attackingState);
                break;
            case CharacterStateEnum.walking:
                SwitchState(walkingState);
                break;            
            case CharacterStateEnum.running:
                SwitchState(runningState);
                break;
            case CharacterStateEnum.Jumping:
                SwitchState(jumpingState);
                break;            
            case CharacterStateEnum.Following:
                SwitchState(followState);
                break;
        }
    }
    public void SwitchState(CharacterBaseState state)
    {
        currentState.OnExit(characterManager);
        currentState = state;
        state.OnEnter(characterManager);
    }

    public void ForceIdleState()
    {
        OnStateChangeRequested(CharacterStateEnum.Idle);
    }
}
