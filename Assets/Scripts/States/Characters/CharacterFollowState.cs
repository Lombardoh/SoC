using Pathfinding;
using UnityEngine;

public class CharacterFollowState : CharacterBaseState
{
    private readonly float changeWaypointDistance = 2f;
    private readonly float arrivalDistance = 4f;
    private readonly float pathUpdateInterval = 0.5f;
    private float lastPathUpdateTime = 0f;

    private int currentWaypoint;
    private Path path;
    private INPCManager NPCManager { get; set; }
    Seeker seeker;
    private void UpdatePath(Seeker seeker, ICharacterManager character)
    {
        seeker.StartPath(character.Transform.position, character.TargetPosition, (p) => PathUtils.OnPathComplete(p, ref path, ref currentWaypoint, character));
    }
    public override void OnEnter(ICharacterManager character)
    {
        if (character.Target == null && character.TargetPosition == null)
        {
            character.CharacterStateManager.OnStateChangeRequested(CharacterState.Idle);
            return;
        }

        NPCManager = character as INPCManager;
        seeker = (character as MonoBehaviour).GetComponent<Seeker>();
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(true);
    }
    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
    }
    public override void Update(ICharacterManager character)
    {
        if (path == null || path.vectorPath == null || currentWaypoint > path.vectorPath.Count)
        {
            if(NPCManager.AssignedTask == UnitTaskType.Wandering)
            {
                character.CharacterStateManager.OnSelectNextState(NPCManager.AssignedTask);
            }
            return;
        }

        if (Time.time - lastPathUpdateTime > pathUpdateInterval)
        {
           UpdatePath(seeker, character); 
        }

        Vector3 flattenedPathPoint = new(path.vectorPath[currentWaypoint].x, 0, path.vectorPath[currentWaypoint].z);
        float distanceToWaypoint = Vector3.Distance(character.Transform.position, flattenedPathPoint);
        if (distanceToWaypoint < changeWaypointDistance)
        {
            currentWaypoint++;
            character.NextPathPoint = path.vectorPath[currentWaypoint];
        }

        Vector3 flattenedTargetPosition = new Vector3(character.TargetPosition.x, 0, character.TargetPosition.z);
        float distanceToTarget = Vector3.Distance(character.Transform.position, flattenedTargetPosition);
        if (distanceToTarget < arrivalDistance)
        {
            character.CharacterStateManager.OnSelectNextState(NPCManager.NextAssignedTask);
            return;
        }

        Vector3 direction = (flattenedPathPoint - character.Transform.position).normalized;
        character.CharacterController.Move(Time.deltaTime * 5f * direction);
    }
}
