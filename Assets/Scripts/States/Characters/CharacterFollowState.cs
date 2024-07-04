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
    private void UpdatePath(Seeker seeker, IUnitManager _IUnitManager)
    {
        seeker.StartPath(_IUnitManager.Transform.position, _IUnitManager.TargetPosition, (p) => PathUtils.OnPathComplete(p, ref path, ref currentWaypoint, _IUnitManager));
    }
    public override void OnEnter(IUnitManager _IUnitManager)
    {
        if (_IUnitManager.Target == null && _IUnitManager.TargetPosition == null)
        {
            _IUnitManager.CharacterStateManager.OnStateChangeRequested(CharacterState.Idle);
            return;
        }

        NPCManager = _IUnitManager as INPCManager;
        seeker = (_IUnitManager as MonoBehaviour).GetComponent<Seeker>();
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorMovementParameter(true);
    }
    public override void OnExit(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
    }
    public override void Update(IUnitManager _IUnitManager)
    {
        if (path == null || path.vectorPath == null || currentWaypoint > path.vectorPath.Count)
        {
            if(NPCManager.AssignedTask == UnitTaskType.Wandering)
            {
                _IUnitManager.CharacterStateManager.OnSelectNextState(NPCManager.AssignedTask);
            }
            return;
        }

        if (Time.time - lastPathUpdateTime > pathUpdateInterval)
        {
           UpdatePath(seeker, _IUnitManager); 
        }

        Vector3 flattenedPathPoint = new(path.vectorPath[currentWaypoint].x, 0, path.vectorPath[currentWaypoint].z);
        float distanceToWaypoint = Vector3.Distance(_IUnitManager.Transform.position, flattenedPathPoint);
        if (distanceToWaypoint < changeWaypointDistance)
        {
            currentWaypoint++;
            _IUnitManager.NextPathPoint = path.vectorPath[currentWaypoint];
        }

        Vector3 flattenedTargetPosition = new(_IUnitManager.TargetPosition.x, 0, _IUnitManager.TargetPosition.z);
        float distanceToTarget = Vector3.Distance(_IUnitManager.Transform.position, flattenedTargetPosition);
        if (distanceToTarget < arrivalDistance)
        {
            _IUnitManager.CharacterStateManager.OnSelectNextState(NPCManager.NextAssignedTask);
            return;
        }

        Vector3 direction = (flattenedPathPoint - _IUnitManager.Transform.position).normalized;
        _IUnitManager.CharacterController.Move(Time.deltaTime * 5f * direction);
    }
}
