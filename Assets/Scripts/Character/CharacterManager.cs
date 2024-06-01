using UnityEngine;

public class CharacterManager : MonoBehaviour, ICharacterManager, IDamageable
{
    public CharacterController characterController;
    public CharacterAnimatorManager characterAnimatorManager;
    public CharacterLocomotionManager characterLocomotionManager;
    public CharacterStateManager characterStateManager;
    public Transform target;
    public GameObject handHitbox;

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
}
