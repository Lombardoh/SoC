using UnityEngine;

public class CharacterManager : MonoBehaviour, ICharacterManager, IDamageable
{
    public CharacterController characterController;
    public CharacterAnimatorManager characterAnimatorManager;
    public CharacterLocomotionManager characterLocomotionManager;
    public CharacterStateManager characterStateManager;
    public GameObject handHitbox;

    protected virtual void Awake()
    {
        characterController = GetComponent<CharacterController>();
        characterAnimatorManager = GetComponent<CharacterAnimatorManager>();
        characterStateManager = GetComponent<CharacterStateManager>();
        characterLocomotionManager = GetComponent<CharacterLocomotionManager>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void LateUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;

        if (other.TryGetComponent<IDamageable>(out var characterManager))
        {
            characterManager.TakeDamage();
        }
    }

    public void TakeDamage()
    {
        characterStateManager.OnStateChangeRequested(CharacterStateEnum.Hurt);
    }
}
