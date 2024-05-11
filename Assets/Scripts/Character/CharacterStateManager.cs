using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    CharacterBaseState currentState;
    CharacterIdleState idleState = new CharacterIdleState();
    CharacterAttackingState attackingState = new CharacterAttackingState();
    CharacterMovingState movingState  = new CharacterMovingState();

    void Start()
    {
        currentState = idleState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(CharacterBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
