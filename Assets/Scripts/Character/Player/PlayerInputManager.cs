using System;
using UnityEngine;
public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;
    public PlayerManager player;
    PlayerControls playerControls;

    [Header("Movement Input")]
    [SerializeField] Vector2 movementInput;
    public float horitontalInput;
    public float verticalInput;
    public float moveAmount;

    [Header("Camera Movement Input")]
    [SerializeField] Vector2 cameraInput;
    public float cameraHoritontalInput;
    public float cameraVerticalInput;

    private bool isAttacking = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerCamera.Movement.performed += i => cameraInput = i.ReadValue<Vector2>();
            playerControls.PlayerAttack.BasicAttacks.performed += context => PerformBasicAttack();
            playerControls.PlayerActions.Jump.performed += context => PerformJump();
            playerControls.PlayerActions.Walk.started += context => StartWalking(true);
            playerControls.PlayerActions.Walk.canceled += context => StartWalking(false);
        }

        InputEvents.OnSetIdle += SetIdle;

        playerControls.Enable();
    }

    private void OnDisable()
    {
        InputEvents.OnSetIdle -= SetIdle;
        playerControls.Disable();
    }

    private void SetIdle()
    {
        isAttacking = false;
    }
    private void PerformBasicAttack()
    {
        if (isAttacking) { return; }
        isAttacking = true;
        player.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Attacking);
    }      
    
    private void StartWalking(bool newValue)
    {
        player.characterLocomotionManager.IsWalking = newValue;
    }      
    
    private void PerformJump()
    {
        if (isAttacking || !player.characterLocomotionManager.IsGrounded) { return; }
        player.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Jumping);
    }    

    private void Update()
    {
        HandleCameraMovementInput();
        if (isAttacking) return;
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horitontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horitontalInput));

        if(!player.playerLocomotionManager.IsGrounded) { return; }

        if(player.characterLocomotionManager.IsWalking && moveAmount > 0)
        {
            moveAmount = 1;
            player.characterStateManager.OnStateChangeRequested(CharacterStateEnum.walking);
            return;
        }

        if(moveAmount > 0)
        {
            moveAmount = 1;
            player.characterStateManager.OnStateChangeRequested(CharacterStateEnum.running);
            return;
        }
        player.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Idle);
    }

    private void HandleCameraMovementInput() 
    {
        cameraVerticalInput= cameraInput.y;
        cameraHoritontalInput= cameraInput.x;
    }
}
