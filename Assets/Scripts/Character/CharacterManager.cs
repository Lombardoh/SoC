using UnityEngine;

public class CharacterManager : MonoBehaviour, ICharacterManager, IDamageable, ITickListener, IWorkable
{
    public CharacterController characterController;
    public CharacterAnimatorManager characterAnimatorManager;
    public CharacterLocomotionManager characterLocomotionManager;
    public CharacterStateManager characterStateManager;

    public Transform target;
    public Vector3 nextPathPoint;
    public Transform city;
    public Transform rock;
    
    public int inventory;
    public int capacity = 10;
    public ResourceType resourceType = ResourceType.nothing;


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

    public void UnloadCargo()
    {
        inventory = 0;
        resourceType = ResourceType.nothing;
        target = rock;
    }

    public void SubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRegisterTickListenerRequested?.Invoke(this, tickTime);
    }    
    
    public void UnsubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRemoveTickListenerRequested?.Invoke(this, tickTime);
    }

    public void OnTicked()
    {
        inventory++;
        if (inventory >= capacity)
        {
            UnsubscribeToTicks(TickTime.Large);
            target = city;
            characterStateManager.OnStateChangeRequested(CharacterStateEnum.Following);
        }
    }
}
