class PathFinder2
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

            var smallDuplicates = path.Where(c => c.IsSmall).GroupBy(c => c.Name).Where(g => g.Count() > 1);
            if (cave.IsSmall && path.Contains(cave) && smallDuplicates.Any())
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