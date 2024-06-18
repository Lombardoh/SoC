using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    private ICharacterManager characterManager;

    public string currentStateString = string.Empty;
    private CharacterState currentStateType = CharacterState.Idle;

    private CharacterBaseState currentState;
    public CharacterBaseState CurrentState
    {
        get { return currentState; }
        set { currentState = value; }
    }    
    public CharacterState CurrentStateType
    {
        get { return currentStateType; }
        set { currentStateType = value; }
    }

    private void Start()
    {
        characterManager = GetComponent<ICharacterManager>();
        characterManager.CharacterStateManager.OnStateChangeRequested(CharacterState.Idle);
        Debug.Log(characterManager);
        currentState.Update(characterManager);
    }

    //void Update()
    //{
    //    if (characterManager == null) return;
    //    currentState.Update(characterManager);
    //}

    public void OnStateChangeRequested(CharacterState newState)
    {
        currentStateString = newState.ToString();
        CurrentStateType = newState;
        if(CurrentState != null)
        {
            currentState.OnExit(characterManager);
        }
        CurrentState = StateFactory.CreateState(newState);
        CurrentState.OnEnter(characterManager);
    }
}
