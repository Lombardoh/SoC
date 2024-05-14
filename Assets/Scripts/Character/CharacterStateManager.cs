using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    public CharacterBaseState currentState;
    public CharacterIdleState idleState = new();
    public CharacterAttackingState attackingState = new();
    public CharacterMovingState movingState  = new();
    public PlayerManager player;
    public GameObject handHitbox;

    private void Awake()
    {
        player = GetComponent<PlayerManager>();
    }
    void Start()
    {
        currentState = idleState;
        currentState.OnEnter(this);
    }

    void Update()
    {
        currentState.Update(this);
    }

    public void SwitchState(CharacterBaseState state)
    {
        currentState = state;
        state.OnEnter(this);
    }

    public void ForceIdleState()
    {
        currentState.OnExit(this);
        PlayerInputManager.instance.isAttacking = false;
        currentState = idleState;
        idleState.OnEnter(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }

    public void takeDamage()
    {

    }
}
