using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    private  CharacterManager characterManager;

    public string currentStateString = string.Empty;

    private CharacterBaseState currentState;
    private readonly CharacterIdleState idleState = new();
    private readonly CharacterMovingState movingState  = new();
    private readonly CharacterHurtState hurtState = new();
    private readonly CharacterAttackingState attackingState = new();
    private readonly CharacterJumpingState jumpingState = new();

    public CharacterBaseState CurrentState
    {
        get { return currentState; }
        set { currentState = value; }
    }

    private void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
    }
    void Start()
    {
        currentState = idleState;
        currentState.OnEnter(characterManager);
    }

    void Update()
    {
        currentState.Update(characterManager);
    }

    public void OnStateChangeRequested(CharacterStateEnum newState)
    {
        currentStateString = newState.ToString();
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
            case CharacterStateEnum.Moving:
                SwitchState(movingState);
                break;
            case CharacterStateEnum.Jumping:
                SwitchState(jumpingState);
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
