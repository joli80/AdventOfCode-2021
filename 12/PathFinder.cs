class PathFinder
{
    public List<List<Cave>> Find(Cave start)
    {
        var paths = new List<List<Cave>>();
        Traverse(new List<Cave>() { start }, paths);
        return paths;
    }

    private void Traverse(List<Cave> path, List<List<Cave>> paths)
    {
        var latestCave = path.Last();
        foreach (var cave in latestCave.Caves)
        {
            if (cave.Order == 0)
                continue;

            if (cave.IsSmall && path.Contains(cave))
                continue;

            var newPath = new List<Cave>(path);
            newPath.Add(cave);
            if (cave.Order == 2)
            {
                paths.Add(newPath);
            }
            else
            {
                Traverse(newPath, paths);
            }
        }
    }
}