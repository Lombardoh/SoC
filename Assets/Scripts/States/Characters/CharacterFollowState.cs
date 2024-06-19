using Pathfinding;
using UnityEngine;

public class CharacterFollowState : CharacterBaseState
{
    private int currentWaypoint;
    private Path path;
    private readonly int changeWaypointDistance = 2;

    public override void OnEnter(ICharacterManager character)
    {
        Debug.Log(character);
        Debug.Log(character.Target);
        //if (character.Target == null)
        //{
        //    character.CharacterStateManager.OnStateChangeRequested(CharacterState.Idle);
        //    return;
        //}

        //MonoBehaviour monoBehaviour = character as MonoBehaviour;
        //if (monoBehaviour == null) { return; }

        //Seeker seeker = monoBehaviour.GetComponent<Seeker>();
        //seeker.StartPath(character.Transform.position, character.Target.transform.position, (path) => OnPathComplete(path, character));

        //character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
    }

    public void OnPathComplete(Path p, ICharacterManager character)
    {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
        character.NextPathPoint = path.vectorPath[currentWaypoint];
    }
    public override void OnExit(ICharacterManager character)
    {
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
    }

    public override void Update(ICharacterManager character)
    {
        if (path == null) { return; }

        if (currentWaypoint >= path.vectorPath.Count - 1)
        {
            character.CharacterStateManager.OnStateChangeRequested(CharacterState.Working);
            return;
        }

        float distanceToWaypoint;
        distanceToWaypoint = Vector3.Distance(character.Transform.position, path.vectorPath[currentWaypoint]);
        if (distanceToWaypoint < changeWaypointDistance)
        {
            currentWaypoint++;
            character.NextPathPoint = path.vectorPath[currentWaypoint];
        }

        character.CharacterController.Move(Time.deltaTime * 5f * character.Transform.forward);
        character.CharacterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
    }
}
