using Pathfinding;
using UnityEngine;

public class CharacterFollowState : CharacterBaseState
{
    private int currentWaypoint;
    private Path path;
    private readonly float changeWaypointDistance = 2f;
    private readonly float arrivalDistance = 5f;
    private readonly float pathUpdateInterval = 0.5f;
    private float lastPathUpdateTime = 0f;
    private INPCManager NPCManager { get; set; }
    Seeker seeker;
    private void UpdatePath(Seeker seeker, ICharacterManager character)
    {
        seeker.StartPath(character.Transform.position, character.TargetPosition, (path) => OnPathComplete(path, character));
    }
    public void OnPathComplete(Path p, ICharacterManager character)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
            character.NextPathPoint = path.vectorPath[currentWaypoint];
        }
    }
    public override void OnEnter(ICharacterManager character)
    {
        if (character.Target == null && character.TargetPosition == null)
        {
            character.CharacterStateManager.OnStateChangeRequested(CharacterState.Idle);
            return;
        }

        NPCManager = character as INPCManager;

        if (character is MonoBehaviour monoBehaviour)
        {
            seeker = monoBehaviour.GetComponent<Seeker>();
            UpdatePath(seeker, character);
        }

        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
    }
    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
    }
    public override void Update(ICharacterManager character)
    {
        if (path == null) return;
        if (Time.time - lastPathUpdateTime > pathUpdateInterval)
        {
            lastPathUpdateTime = Time.time;
            if (character is MonoBehaviour monoBehaviour)
            {
                seeker = monoBehaviour.GetComponent<Seeker>();
                UpdatePath(seeker, character);
            }
        }

        float distanceToWaypoint = Vector3.Distance(character.Transform.position, path.vectorPath[currentWaypoint]);
        if (distanceToWaypoint < changeWaypointDistance)
        {
            currentWaypoint++;
            character.NextPathPoint = path.vectorPath[currentWaypoint];
        }

        float distanceToTarget = Vector3.Distance(character.Transform.position, character.TargetPosition);

        if (distanceToTarget < arrivalDistance)
        {
            character.CharacterStateManager.OnSelectNextState(NPCManager.UnitActionType);
        }

        Vector3 direction = (path.vectorPath[currentWaypoint] - character.Transform.position).normalized;
        character.CharacterController.Move(Time.deltaTime * 5f * direction);
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(direction.x, direction.z);
    }
}
