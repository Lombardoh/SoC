using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    CharacterManager character;

    private void OnEnable()
    {
        AnimatorEvents.OnAnimateJumping += UpdateAnimatorGroundingParameter;
    }

    private void OnDisable()
    {
        AnimatorEvents.OnAnimateJumping -= UpdateAnimatorGroundingParameter;        
    }

    private void Awake()
    {
        character = GetComponent<CharacterManager>();
    }
    public void UpdateAnimatorMovementParameter(float horizontalValue, float verticalValue)
    {
        character.animator.SetFloat("Horizontal", horizontalValue);
        character.animator.SetFloat("Vertical", verticalValue);
    }

    public void UpdateAnimatorAttackParameter(bool isAttacking)
    {
        character.animator.SetBool("isAttacking", isAttacking);
    }    
    
    public void UpdateAnimatorGroundingParameter(bool isGrounded)
    {
        character.animator.SetBool("isGrounded", isGrounded);
    }
}
