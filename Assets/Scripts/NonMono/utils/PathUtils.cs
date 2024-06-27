using Pathfinding;
public static class PathUtils
{
    public static Path UpdatePath(Seeker seeker, ICharacterManager character)
    {
        Path path = seeker.StartPath(character.Transform.position, character.TargetPosition, (p) => OnPathComplete(p));
        return path;
    }
    public static Path OnPathComplete(Path p)
    {
        Path path = p;
        if (!p.error)
        {
            path = p;
        }
        return path;
    }
}
