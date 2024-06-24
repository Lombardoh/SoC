using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void UpdateAnimatorMovementParameter(bool isWalking)
    {
        animator.SetBool("IsWalking", isWalking);
    }

    public void UpdateAnimatorAttackParameter(bool isAttacking)
    {
        animator.SetBool("IsAttacking", isAttacking);
    }       
    
    public void UpdateAnimatorWorkingParameter(bool isWorking)
    {
        animator.SetBool("IsWorking", isWorking);
    }    
    
    public void UpdateAnimatorGroundingParameter(bool isGrounded)
    {
        animator.SetBool("IsGrounded", isGrounded);
    }    
    public void UpdateAnimatorWasHurtParameter(bool wasHurt)
    {
        animator.SetBool("Hurt", wasHurt);
    }    
    public void UpdateAnimatorIsDyingParameter(bool isDying)
    {
        animator.SetBool("IsDying", isDying);
    }
}
