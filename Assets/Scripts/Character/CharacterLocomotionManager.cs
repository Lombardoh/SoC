using UnityEngine;

public class CharacterLocomotionManager : MonoBehaviour
{
    public CharacterManager character;
    public Transform groundCheckTransform;
    public LayerMask groundLayer;

    [SerializeField] private bool isGrounded;
    protected Vector3 moveDirection;
    public CharacterController characterController;

    [SerializeField] float walkingSpeed = 2;
    [SerializeField] float runningSpeed = 5;
    [SerializeField] protected float rotationSpeed = 15;
    [SerializeField] float currentSpeed;
    [SerializeField] bool isWalking;

    public float CurrentSpeed
    {
        get { return currentSpeed; }
        set
        {
            if (currentSpeed != value)
            {
                currentSpeed = value;
            }
        }
    }    
    public bool IsWalking
    {
        get { return isWalking; }
        set
        {
            if (isWalking != value)
            {
                isWalking = value;
                OnIsWalking(value);
            }
        }
    }

    public bool IsGrounded
    {
        get { return isGrounded; }
        set
        {
            if (isGrounded != value)
            {
                isGrounded = value;
                OnIsGroundedChanged(isGrounded);
            }
        }
    }

    protected virtual void OnIsGroundedChanged(bool newValue)
    {
        if(newValue == true)
        {
            //character.characterStateManager.OnStateChangeRequested(CharacterState.Idle);
            moveDirection.y = 0;
        }
    }    
    
    protected virtual void OnIsWalking(bool newValue)
    {
        if(newValue == true)
        {
            currentSpeed = walkingSpeed;
            return;
        }
        currentSpeed = runningSpeed;
    }
    protected virtual void Awake()
    {
        characterController = GetComponent<CharacterController>();
        character= GetComponent<CharacterManager>();
        currentSpeed = runningSpeed;
    }

    public virtual void HandleAllMovement()
    {
        RotateTowards();
    }

    public virtual void RotateTowards()
    {
        Vector3 lookAtTarget = new(character.NextPathPoint.x, transform.position.y, character.NextPathPoint.z);
        transform.LookAt(lookAtTarget);
    }    
    public virtual void LookAtTarget()
    {
        Vector3 lookAtTarget = new(character.TargetPosition.x, transform.position.y, character.TargetPosition.z);
        transform.LookAt(lookAtTarget);
    }
}
