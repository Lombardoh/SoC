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

    public override void OnEnter(ICharacterManager character)
    {
        if (character.Target == null)
        {
            character.CharacterStateManager.OnStateChangeRequested(CharacterState.Idle);
            return;
        }

        NPCManager = character as INPCManager;

        if (character is MonoBehaviour monoBehaviour)
        {
            Seeker seeker = monoBehaviour.GetComponent<Seeker>();
            seeker.StartPath(character.Transform.position, character.Target.transform.position, (path) => OnPathComplete(path, character));
        }

        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
    }

    private void UpdatePath(Seeker seeker, ICharacterManager character)
    {
        seeker.StartPath(character.Transform.position, character.Target.transform.position, (path) => OnPathComplete(path, character));
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
                Seeker seeker = monoBehaviour.GetComponent<Seeker>();
                UpdatePath(seeker, character);
            }
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            character.CharacterStateManager.OnStateChangeRequested(CharacterState.Working);
            return;
        }

        float distanceToWaypoint = Vector3.Distance(character.Transform.position, path.vectorPath[currentWaypoint]);
        if (distanceToWaypoint < changeWaypointDistance)
        {
            currentWaypoint++;
            if (currentWaypoint >= path.vectorPath.Count)
            {
                character.CharacterStateManager.OnStateChangeRequested(CharacterState.Working);
                return;
            }
            character.NextPathPoint = path.vectorPath[currentWaypoint];
        }

        float distanceToTarget = Vector3.Distance(character.Transform.position, character.Target.transform.position);

        if (distanceToTarget < arrivalDistance)
        {
            if (NPCManager.UnitActionType == UnitActionType.Gathering)
            {
                character.CharacterStateManager.OnStateChangeRequested(CharacterState.Working);
                return;
            }
            else if (NPCManager.UnitActionType == UnitActionType.Depositing)
            {
                character.CharacterStateManager.OnStateChangeRequested(CharacterState.Depositing);
                return;
            }
        }

        Vector3 direction = (path.vectorPath[currentWaypoint] - character.Transform.position).normalized;
        character.CharacterController.Move(Time.deltaTime * 5f * direction);
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(direction.x, direction.z);
    }
}
