public static class StateFactory
{
    public static CharacterBaseState CreateState(CharacterStateEnum newState)
    {
        switch (newState)
        {
            case CharacterStateEnum.Idle:
                return new CharacterIdleState();                
            case CharacterStateEnum.walking:
                return new CharacterWalkingState();
            case CharacterStateEnum.running:
                return new CharacterRunningState();
            case CharacterStateEnum.Hurt:
                return new CharacterHurtState();                
            case CharacterStateEnum.Attacking:
                return new CharacterAttackingState();
            case CharacterStateEnum.Jumping:
                return new CharacterJumpingState();
            case CharacterStateEnum.Following:
                return new CharacterFollowState();                
            case CharacterStateEnum.Working:
                return new CharacterWorkingState();    
        }
        return null;
    }
}
