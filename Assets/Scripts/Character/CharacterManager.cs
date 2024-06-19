using UnityEngine;

public class CharacterManager : MonoBehaviour, ICharacterManager, IDamageable, ITickListener
{
    public GameObject Target { get; set; }
    public Vector3 NextPathPoint { get; set; }

    public CharacterStateManager CharacterStateManager { get; set; }
    public CharacterAnimatorManager CharacterAnimatorManager { get; set; }
    public CharacterLocomotionManager CharacterLocomotionManager { get; set; }

    public ITickListener TickListener { get; set; }
    public Transform Transform { get; set; }
    public CharacterController CharacterController { get; set; }


    protected virtual void Awake()
    {
        CharacterStateManager = GetComponent<CharacterStateManager>();
        CharacterAnimatorManager = GetComponent<CharacterAnimatorManager>();
        CharacterLocomotionManager = GetComponent<CharacterLocomotionManager>();

        CharacterController = GetComponent<CharacterController>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        CharacterLocomotionManager.HandleAllMovement();
    }
    protected virtual void LateUpdate()
    {
    }

    public void TakeDamage()
    {
        CharacterStateManager.OnStateChangeRequested(CharacterState.Hurt);
    }    
    
    public void SubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRegisterTickListenerRequested?.Invoke(this, tickTime);
    }

    public void UnsubscribeToTicks()
    {
        UnsubscribeToTicks(TickTime.Large);
    }    

    private void UnsubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRemoveTickListenerRequested?.Invoke(this, tickTime);
    }

    public void OnTicked()
    {

    }
}
