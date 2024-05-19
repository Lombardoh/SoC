using System;

public static class AnimatorEvents
{
    public static Action <bool> OnAnimateJumping;
    public static Action <bool> OnGettingHit;
    public static Action OnAttackAnimationRequested;
}