using UnityEngine;

public interface IUnitManager
{
    public GameObject Target { get; set; }
    public Vector3 TargetPosition { get { return Target.transform.position; } }
    public CharacterController CharacterController { get; set; }
    public Vector3 NextPathPoint { get; set; }
    Transform Transform { get; }

    CharacterStateManager CharacterStateManager { get; set; }
    CharacterAnimatorManager CharacterAnimatorManager { get; set; }
    CharacterLocomotionManager CharacterLocomotionManager { get; set; }

    ITickListener TickListener { get; set; }

    public Transform AttackHitBox { get; set; }
    public bool LockedInAnimation { get; set; }
}

