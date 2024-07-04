using System;
using UnityEngine;
public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;
    public UnitManager player;
    PlayerControls playerControls;

    private IInteractable interactableObject;

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
            playerControls.PlayerActions.Interact.performed += context => PerformInteraction();
            playerControls.PlayerActions.Walk.started += context => StartWalking(true);
            playerControls.PlayerActions.Walk.canceled += context => StartWalking(false);
        }

        InputEvents.OnSetIdle += SetIdle;
        InteractionEvents.OnUpdateInteractableObject += UpdateInteractableObject;

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
    private void UpdateInteractableObject(IInteractable InteractableObject)
    {
        this.interactableObject = InteractableObject;
    }
    private void PerformInteraction()
    {
        if (interactableObject == null) { return; }
        interactableObject.PerformInteraction();
    }
    private void PerformBasicAttack()
    {
        if (isAttacking) { return; }
        isAttacking = true;
        player.CharacterStateManager.OnStateChangeRequested(CharacterState.Attacking);
    }         
    private void StartWalking(bool newValue)
    {
        player.CharacterLocomotionManager.IsWalking = newValue;
    }      
    private void PerformJump()
    {
        if (isAttacking || !player.CharacterLocomotionManager.IsGrounded) { return; }
        player.CharacterStateManager.OnStateChangeRequested(CharacterState.Jumping);
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

        if(!player.CharacterLocomotionManager.IsGrounded) { return; }
        if(player.CharacterLocomotionManager.IsWalking && moveAmount > 0)
        {
            moveAmount = 1;
            player.CharacterStateManager.OnStateChangeRequested(CharacterState.walking);
            return;
        }

        if(moveAmount > 0)
        {
            moveAmount = 1;
            player.CharacterStateManager.OnStateChangeRequested(CharacterState.running);
            return;
        }
        player.CharacterStateManager.OnStateChangeRequested(CharacterState.Idle);
    }

    private void HandleCameraMovementInput() 
    {
        cameraVerticalInput= cameraInput.y;
        cameraHoritontalInput= cameraInput.x;
    }
}
