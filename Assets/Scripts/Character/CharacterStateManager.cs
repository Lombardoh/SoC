using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    private ICharacterManager characterManager;
    public  CharacterBaseState CurrentState { get; set; }
    
    public string currentStateString = string.Empty;
    public CharacterState CurrentStateType { get; set; } = CharacterState.Idle;

    private void Awake()
    {
        characterManager = GetComponent<ICharacterManager>();
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
}
