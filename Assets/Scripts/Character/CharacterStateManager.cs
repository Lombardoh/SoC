using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    private ICharacterManager characterManager;

    public string currentStateString = string.Empty;
    private CharacterState currentStateType = CharacterState.Idle;

    public  CharacterBaseState CurrentState { get; set; }

    public CharacterState CurrentStateType
    {
        get { return currentStateType; }
        set { currentStateType = value; }
    }

    private void Start()
    {
        characterManager = GetComponent<ICharacterManager>();
        characterManager.CharacterStateManager.OnStateChangeRequested(CharacterState.Idle);
        CurrentState.Update(characterManager);
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
        if(CurrentState != null)
        {
            CurrentState.OnExit(characterManager);
        }
        CurrentState = StateFactory.CreateState(newState);
        CurrentState.OnEnter(characterManager);
    }
}
