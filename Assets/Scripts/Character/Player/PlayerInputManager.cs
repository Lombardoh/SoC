using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

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

    public bool isAttacking = false;

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

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void PerformBasicAttack()
    {
        isAttacking = true;
    }    
    private void PerformJump()
    {
        InputEvents.OnJumpButtonDown?.Invoke();
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

        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput + Mathf.Abs(horitontalInput)));

        if(moveAmount > 0)
        {
            moveAmount = 1;
        }
    }

    private void HandleCameraMovementInput() 
    {
        cameraVerticalInput= cameraInput.y;
        cameraHoritontalInput= cameraInput.x;
    }
}
