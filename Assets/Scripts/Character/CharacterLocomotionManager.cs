using UnityEngine;

public class CharacterLocomotionManager : MonoBehaviour
{
    public Transform groundCheckTransform;
    public LayerMask groundLayer;
    public float groundDistance = 0.1f;
    public float jumpForce = 20;
    public float gravityForce = 9.8f;

    [SerializeField] private bool isGrounded;
    protected Vector3 moveDirection;
    public CharacterController characterController;
    public CharacterManager character;

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
    public void AttempToPerformJump()
    {
        moveDirection.Normalize();
        moveDirection.y = jumpForce;
        characterController.Move(moveDirection * Time.deltaTime);
    }
    protected virtual bool CheckGrounded()
    {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayer);
        return IsGrounded;
    }
    public virtual void HandleAllMovement()
    {
        RotateTowards();
    }

    public virtual void RotateTowards()
    {

    }
}
