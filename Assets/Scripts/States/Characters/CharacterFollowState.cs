using Pathfinding;
using UnityEngine;

public class CharacterFollowState : CharacterBaseState
{
    private int currentWaypoint;
    private Path path;
    private readonly int changeWaypointDistance = 2;

    public override void OnEnter(CharacterManager character)
    {
        if (character.target == null)
        {
            character.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Idle);
            return;
        }
        Seeker seeker = character.GetComponent<Seeker>();
        seeker.StartPath(character.transform.position, character.target.transform.position, (path) => OnPathComplete(path, character));

        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
    }
    public void OnPathComplete(Path p, CharacterManager character)
    {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
        character.nextPathPoint = path.vectorPath[currentWaypoint];
    }
    public override void OnExit(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
    }

    public override void Update(CharacterManager character)
    {
        if (path == null) { return; }

        if (currentWaypoint >= path.vectorPath.Count - 1)
        {
            character.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Working);
            return;
        }

        float distanceToWaypoint;
        distanceToWaypoint = Vector3.Distance(character.transform.position, path.vectorPath[currentWaypoint]);
        if (distanceToWaypoint < changeWaypointDistance)
        {
            currentWaypoint++;
            character.nextPathPoint = path.vectorPath[currentWaypoint];
        }

        character.characterController.Move(Time.deltaTime * 5f * character.transform.forward);
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
    }
}
