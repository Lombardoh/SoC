public static class StateFactory
{
    public static CharacterBaseState CreateState(CharacterState newState)
    {
        switch (newState)
        {
            case CharacterState.Idle:
                return new CharacterIdleState();                
            case CharacterState.walking:
                return new CharacterWalkingState();
            case CharacterState.running:
                return new CharacterRunningState();
            case CharacterState.Hurt:
                return new CharacterHurtState();                
            case CharacterState.Attacking:
                return new CharacterAttackingState();
            case CharacterState.Jumping:
                return new CharacterJumpingState();
            case CharacterState.Following:
                return new CharacterFollowState();                
            case CharacterState.Working:
                return new CharacterWorkingState();
            case CharacterState.Depositing:
                return new CharacterDepositingState();              
            case CharacterState.Dying:
                return new CharacterDyingState();               
            case CharacterState.Fithing:
                return new CharacterFightingState();    
        }
        return null;
    }
}
