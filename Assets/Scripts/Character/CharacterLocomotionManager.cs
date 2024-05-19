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

    public bool IsGrounded
    {
        get { return isGrounded; }
        set
        {
            if (isGrounded != value)
            {
                Debug.Log(value);
                isGrounded = value;
                OnIsGroundedChanged(isGrounded);
            }
        }
    }

    protected virtual void OnIsGroundedChanged(bool newValue)
    {
        if(newValue == true)
        {
            character.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Idle);
        }
    }
    protected virtual void Awake()
    {
        characterController = GetComponent<CharacterController>();
        character= GetComponent<CharacterManager>();
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
}
