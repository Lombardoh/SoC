using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    private CharacterManager characterManager;

    public string currentStateString = string.Empty;
    private CharacterStateEnum currentStateType = CharacterStateEnum.Idle;

    private CharacterBaseState currentState;
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
        
    }

    private void Start()
    {
        OnStateChangeRequested(CharacterStateEnum.Idle);
    }

    void Update()
    {
        currentState.Update(characterManager);
    }

    public void OnStateChangeRequested(CharacterStateEnum newState)
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
