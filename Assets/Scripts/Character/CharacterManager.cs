using UnityEngine;

public class CharacterManager : MonoBehaviour, ICharacterManager, IDamageable, ITickListener
{
    Character character;
    public GameObject Target { get; set; }
    public Vector3 TargetPosition { get; set; }
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
    public void OnTicked()
    {
        character.ResourceAmount += 1;
        if (character.ResourceAmount >= character.ResourceCapacity)
        {
            Target = UnitUtils.FindClosestTarget(this.transform, TagType.City);
            TargetPosition = Target.transform.position;
            CharacterStateManager.OnStateChangeRequested(CharacterState.Following);
        }
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
