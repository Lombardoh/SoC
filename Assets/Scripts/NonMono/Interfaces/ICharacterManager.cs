using UnityEngine;

public interface ICharacterManager
{
    CharacterStateManager CharacterStateManager { get; set; }
    CharacterAnimatorManager CharacterAnimatorManager { get; set; }
    CharacterLocomotionManager CharacterLocomotionManager { get; set; }
    ITickListener TickListener { get; set; }
    Transform Transform { get; }

    public CharacterController CharacterController { get; set; }

    public Vector3 NextPathPoint { get; set; }
}

