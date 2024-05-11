using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        Debug.Log("idling");
    }

    public override void UpdateState(CharacterStateManager character)
    {
        throw new System.NotImplementedException();
    }
}
