using Pathfinding;
using UnityEngine;

public class CharacterFightingState : CharacterBaseState
{
    private readonly float changeWaypointDistance = 0.5f;
    private readonly float attackRange = 2f;
    private readonly float pathUpdateInterval = 0.5f;
    private float lastPathUpdateTime = 0f;

    Seeker seeker;
    Path path;
    int currentWaypoint;
    private void UpdatePath(Seeker seeker, ICharacterManager character)
    {
        seeker.StartPath(character.Transform.position, character.TargetPosition, (p) => PathUtils.OnPathComplete(p, ref path, ref currentWaypoint, character));
    }
    public override void OnEnter(ICharacterManager character)
    {
        seeker = (character as MonoBehaviour).GetComponent<Seeker>();
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(true);
    }

    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
    }

    public override void Update(ICharacterManager character)
    {
        if (character.Target == null && character.TargetPosition == null){ return; }
        if (path == null || path.vectorPath == null || currentWaypoint > path.vectorPath.Count) { UpdatePath(seeker, character); return; }

        if (Time.time - lastPathUpdateTime > pathUpdateInterval)
        {
            UpdatePath(seeker, character);
        }

        float distanceToTarget = Vector3.Distance(character.Transform.position, character.TargetPosition);
        if (distanceToTarget < attackRange)
        {
            character.CharacterStateManager.OnStateChangeRequested(CharacterState.Attacking);
            return;
        }

        float distanceToWaypoint = Vector3.Distance(character.Transform.position, character.NextPathPoint);
        
        if (distanceToWaypoint < changeWaypointDistance)
        {
            currentWaypoint++;
            character.NextPathPoint = path.vectorPath[currentWaypoint];
        }

        Vector3 direction = (character.NextPathPoint - character.Transform.position).normalized;
        character.CharacterController.Move(Time.deltaTime * 5f * direction);
    }
}
