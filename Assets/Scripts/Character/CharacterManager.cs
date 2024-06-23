using UnityEngine;

public class CharacterManager : MonoBehaviour, ICharacterManager, IDamageable, ITickListener
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

    public int resource; //remove this once character have their own resource panels

    protected virtual void Awake()
    {
        CharacterStateManager = GetComponent<CharacterStateManager>();
        CharacterAnimatorManager = GetComponent<CharacterAnimatorManager>();
        CharacterLocomotionManager = GetComponent<CharacterLocomotionManager>();
        CharacterController = GetComponent<CharacterController>();
    }
    protected virtual void Start()
    {
        character = new(0,20);
    }
    protected virtual void Update()
    {
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
}
