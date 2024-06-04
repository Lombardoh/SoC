using UnityEngine;

public class CharacterManager : MonoBehaviour, ICharacterManager, IDamageable, ITickListener, IWorkable
{
    public CharacterController characterController;
    public CharacterAnimatorManager characterAnimatorManager;
    public CharacterLocomotionManager characterLocomotionManager;
    public CharacterStateManager characterStateManager;
    public Transform target;
    public GameObject handHitbox;
    public int inventory;
    public ResourceType resourceType;

    protected virtual void Awake()
    {
        characterController = GetComponent<CharacterController>();
        characterAnimatorManager = GetComponent<CharacterAnimatorManager>();
        characterStateManager = GetComponent<CharacterStateManager>();
        characterLocomotionManager = GetComponent<CharacterLocomotionManager>();
    }

    protected virtual void Start()
    {
        QualitySettings.vSyncCount = 1;
    }

    protected virtual void Update()
    {
        characterLocomotionManager.HandleAllMovement();
    }

    protected virtual void LateUpdate()
    {

    }

    public void TakeDamage()
    {
        characterStateManager.OnStateChangeRequested(CharacterStateEnum.Hurt);
    }    
    
    public void StartWorking(ResourceType resourceType)
    {
        this.resourceType = resourceType;
        characterStateManager.OnStateChangeRequested(CharacterStateEnum.Working);
        SubscribeToTicks(TickTime.Large);
    }

    public void SubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRegisterTickListenerRequested.Invoke(this, tickTime);
    }

    public void OnTicked()
    {
        inventory++;
    }
}
