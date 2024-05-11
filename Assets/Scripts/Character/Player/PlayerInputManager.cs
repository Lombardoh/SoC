using System;
using UnityEngine;
using UnityEngine.InputSystem;

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
            playerControls.PlayerAttack.BasicAttacks.performed += context => performBasicAttack();

        }

        playerControls.Enable();
    }

    public void OnAnimationEnd()
    {
        // This method will be called when the animation ends
        Debug.Log("Animation ended");
    }

    private void performBasicAttack()
    {
        isAttacking = !isAttacking;
        verticalInput = 0;
        horitontalInput = 0;
        player.playerAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
        player.playerAnimatorManager.UpdateAnimatorAttackParameter(isAttacking);
    }

    private void OnDisable()
    {
        playerControls.Disable();
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

        if( moveAmount <= 0.5 && moveAmount > 0 )
        {
            moveAmount = 0.5f;
        }else if(moveAmount > 0.5 && moveAmount <= 1)
        {
            moveAmount = 1;
        }

        player.playerAnimatorManager.UpdateAnimatorMovementParameter(0, moveAmount);
    }

    private void HandleCameraMovementInput() 
    {
        cameraVerticalInput= cameraInput.y;
        cameraHoritontalInput= cameraInput.x;
    }
}
