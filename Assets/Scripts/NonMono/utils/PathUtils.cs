using Pathfinding;
using UnityEngine;
public static class PathUtils
{
    public static void UpdatePath(Seeker seeker, ICharacterManager character)
    {
        //seeker.StartPath(character.Transform.position, character.TargetPosition, (p) => OnPathComplete(p, character));
    }
    public static void OnPathComplete(Path p, ref Path path, ref int currentWaypoint, ICharacterManager character)
    {
        if (p.error) { return; }
        path = p;
        currentWaypoint = 0;
        character.NextPathPoint = path.vectorPath[currentWaypoint];
    }
}
