using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotionManager : CharacterLocomotionManager
{
    PlayerManager player;

    public Transform groundCheckTransform;
    public LayerMask groundLayer;
    public float groundDistance = 1000;
    public float jumpForce = 200;
    public float gravityForce = 9.8f;

    public float verticalMovement;
    public float horizontalMovement;
    public float moveAmount;
    [SerializeField] private bool isGrounded;

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
        AnimatorEvents.OnAnimateJumping(newValue);
    }

    private Vector3 moveDirection;
    private Vector3 targetRotationDirection = Vector3.zero;
    [SerializeField] float walkingSpeed = 2;
    [SerializeField] float runningSpeed = 5;
    [SerializeField] float rotationSpeed = 15;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<PlayerManager>();
    }

    private void OnEnable()
    {
        InputEvents.OnJumpButtonDown += HandleJumpingMovement;
    }

    private void OnDisable()
    {
        InputEvents.OnJumpButtonDown -= HandleJumpingMovement;
    }

    public void HandleAllMovement()
    {
        HandleRotation();
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayer);
        if (!isGrounded) 
        {
            HandleAiredMovement();
            return;
        };
        HandleGroundedMovement();
    }

    private void OnDrawGizmos()
    {
        // Draw a red line representing the raycast in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundDistance);
    }


    public void GetVerticalAndHorizontalMovement()
    {
        verticalMovement = PlayerInputManager.instance.verticalInput;
        horizontalMovement = PlayerInputManager.instance.horitontalInput;
    }    
    public void HandleJumpingMovement()
    {
        moveDirection.Normalize();
        moveDirection.y = jumpForce;
        player.characterController.Move(moveDirection * Time.deltaTime);

    }    
    public void HandleAiredMovement()
    {
        moveDirection.y -= gravityForce;
        player.characterController.Move(moveDirection * Time.deltaTime);
    }
    private void HandleGroundedMovement()
    {
        GetVerticalAndHorizontalMovement();
        moveDirection = PlayerCamera.Instance.transform.forward * verticalMovement;
        moveDirection = moveDirection + PlayerCamera.Instance.transform.right * horizontalMovement;
        moveDirection.Normalize();
        moveDirection.y = 0;

         if(PlayerInputManager.instance.moveAmount > 0)
        {
            player.characterController.Move(moveDirection * walkingSpeed * Time.deltaTime);
        }
    }
    private void HandleRotation()
    {
        targetRotationDirection = Vector3.zero;
        targetRotationDirection = PlayerCamera.Instance.cameraObject.transform.forward * verticalMovement;
        targetRotationDirection = targetRotationDirection + PlayerCamera.Instance.cameraObject.transform.right * horizontalMovement;
        targetRotationDirection.Normalize();
        targetRotationDirection.y = 0;

        if(targetRotationDirection == Vector3.zero)
        {
            targetRotationDirection = transform.forward;
        }

        Quaternion newRotation = Quaternion.LookRotation(targetRotationDirection);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = targetRotation;
    }
}
