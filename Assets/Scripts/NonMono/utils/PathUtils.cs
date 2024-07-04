using Pathfinding;
using UnityEngine;
public static class PathUtils
{
    public static void UpdatePath(Seeker seeker, IUnitManager _IUnitManager)
    {
        //seeker.StartPath(character.Transform.position, character.TargetPosition, (p) => OnPathComplete(p, character));
    }
    public static void OnPathComplete(Path p, ref Path path, ref int currentWaypoint, IUnitManager _IUnitManager)
    {
        if (p.error) { return; }
        path = p;
        currentWaypoint = 0;
        _IUnitManager.NextPathPoint = path.vectorPath[currentWaypoint];
    }
}
