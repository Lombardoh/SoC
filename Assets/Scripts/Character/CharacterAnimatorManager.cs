using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void UpdateAnimatorMovementParameter(float horizontalValue, float verticalValue)
    {
        animator.SetFloat("Horizontal", horizontalValue);
        animator.SetFloat("Vertical", verticalValue);
    }

    public void UpdateAnimatorAttackParameter(bool isAttacking)
    {
        animator.SetBool("isAttacking", isAttacking);
    }    
    
    public void UpdateAnimatorGroundingParameter(bool isGrounded)
    {
        animator.SetBool("isGrounded", isGrounded);
    }    
    public void UpdateAnimatorWasHurtParameter(bool wasHurt)
    {
        animator.SetBool("Hurt", wasHurt);
    }
}
