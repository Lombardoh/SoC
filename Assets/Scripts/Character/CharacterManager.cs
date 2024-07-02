using UnityEngine;

public class CharacterManager : MonoBehaviour, ICharacterManager, IDamageable, ITickListener, ICombatable
{
    protected Character character;
    [SerializeField] private GameObject target;
    public GameObject Target { get { return target; } set { target = value; } }
    public Vector3 TargetPosition { get { return Target.transform.position; }}
    public Vector3 NextPathPoint { get; set; }
    public CharacterStateManager CharacterStateManager { get; set; }
    public CharacterAnimatorManager CharacterAnimatorManager { get; set; }
    public CharacterLocomotionManager CharacterLocomotionManager { get; set; }
    public ITickListener TickListener { get; set; }
    public Transform Transform { get { return transform; }}
    public CharacterController CharacterController { get; set; }
    public bool LockedInAnimation { get; set; } = false;
    public Transform AttackHitBox { get; set; }

    public int resource; //remove this once character have their own resource panels
    protected virtual void Awake()
    {
        CharacterStateManager = GetComponent<CharacterStateManager>();
        CharacterAnimatorManager = GetComponent<CharacterAnimatorManager>();
        CharacterLocomotionManager = GetComponent<CharacterLocomotionManager>();
        CharacterController = GetComponent<CharacterController>();
        AttackHitBox = GameUtils.GetInactiveChild(transform, "AttackHitbox");        
    }
    protected virtual void Start()
    {
        character = new(0,20);
        
    }
    protected virtual void Update()
    {
        if (LockedInAnimation) { return; }
        CharacterLocomotionManager.HandleAllMovement();
        resource = character.ResourceAmount; //remove this once character have their own resource panels
    }
    protected virtual void LateUpdate()
    {
    }
    public void TakeDamage()
    {
        CharacterStateManager.OnStateChangeRequested(CharacterState.Hurt);
    }        
    public void Die()
    {
        CharacterStateManager.OnStateChangeRequested(CharacterState.Dying);
    }        
    public void Dispose()
    {
        Destroy(gameObject);
    }    
    public virtual void OnTicked()
    {

    }
    public void EmptyResource()
    {
        character.ResourceAmount = 0;
    }       
    public int GetResourceAmount()
    {
        return character.ResourceAmount;
    }
    public void StartCombat()
    {
        CharacterStateManager.OnStateChangeRequested(CharacterState.Fighting);
    }
}
