using UnityEngine;

public class PlayerLocomotionManager : CharacterLocomotionManager
{
    PlayerManager player;

    public float verticalMovement;
    public float horizontalMovement;
    public float moveAmount;

    private Vector3 targetRotationDirection = Vector3.zero;
    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<PlayerManager>();
    }
    public override void HandleAllMovement()
    {
        base.HandleAllMovement();
        HandleRotation();
        if (!CheckGrounded()) 
        {
            HandleAiredMovement();
            return;
        };
        HandleGroundedMovement();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundDistance);
    }

    public void GetVerticalAndHorizontalMovement()
    {
        verticalMovement = PlayerInputManager.instance.verticalInput;
        horizontalMovement = PlayerInputManager.instance.horitontalInput;
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
        moveDirection += PlayerCamera.Instance.transform.right * horizontalMovement;
        moveDirection.Normalize();
        moveDirection.y = 0;

         if(PlayerInputManager.instance.moveAmount > 0)
        {
            player.characterController.Move(Time.deltaTime * CurrentSpeed * moveDirection);
        }
    }
    private void HandleRotation()
    {
        targetRotationDirection = Vector3.zero;
        targetRotationDirection = PlayerCamera.Instance.cameraObject.transform.forward * verticalMovement;
        targetRotationDirection += PlayerCamera.Instance.cameraObject.transform.right * horizontalMovement;
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
