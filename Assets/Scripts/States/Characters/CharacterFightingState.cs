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
    private void UpdatePath(Seeker seeker, IUnitManager _IUnitManager)
    {
        seeker.StartPath(_IUnitManager.Transform.position, _IUnitManager.TargetPosition, (p) => PathUtils.OnPathComplete(p, ref path, ref currentWaypoint, _IUnitManager));
    }
    public override void OnEnter(IUnitManager _IUnitManager)
    {
        seeker = (_IUnitManager as MonoBehaviour).GetComponent<Seeker>();
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorMovementParameter(true);
    }

    public override void OnExit(IUnitManager _IUnitManager)
    {
        _IUnitManager.CharacterAnimatorManager.UpdateAnimatorMovementParameter(false);
    }

    public override void Update(IUnitManager _IUnitManager)
    {
        if (_IUnitManager.Target == null && _IUnitManager.TargetPosition == null){ return; }
        if (path == null || path.vectorPath == null || currentWaypoint > path.vectorPath.Count) { UpdatePath(seeker, _IUnitManager); return; }

        if (Time.time - lastPathUpdateTime > pathUpdateInterval)
        {
            UpdatePath(seeker, _IUnitManager);
        }

        float distanceToTarget = Vector3.Distance(_IUnitManager.Transform.position, _IUnitManager.TargetPosition);
        if (distanceToTarget < attackRange)
        {
            _IUnitManager.CharacterStateManager.OnStateChangeRequested(CharacterState.Attacking);
            return;
        }

        float distanceToWaypoint = Vector3.Distance(_IUnitManager.Transform.position, _IUnitManager.NextPathPoint);
        
        if (distanceToWaypoint < changeWaypointDistance)
        {
            currentWaypoint++;
            _IUnitManager.NextPathPoint = path.vectorPath[currentWaypoint];
        }

        Vector3 direction = (_IUnitManager.NextPathPoint - _IUnitManager.Transform.position).normalized;
        _IUnitManager.CharacterController.Move(Time.deltaTime * 5f * direction);
    }
}
