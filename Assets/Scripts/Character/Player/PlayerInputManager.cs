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

        }

        InputEvents.OnSetIdle += setIdle;

        playerControls.Enable();
    }

    private void OnDisable()
    {
        InputEvents.OnSetIdle -= setIdle;
        playerControls.Disable();
    }

    private void setIdle()
    {
        isAttacking = false;
    }
    private void PerformBasicAttack()
    {
        isAttacking = true;
        player.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Attacking);
    }      
    
    private void PerformJump()
    {
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

        if(moveAmount > 0)
        {
            moveAmount = 1;
            player.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Moving);
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
