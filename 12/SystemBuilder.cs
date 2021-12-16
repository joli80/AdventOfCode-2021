class SystemBuilder
{
    public List<Cave> Build(string map)
    {
        List<Cave> caves = new();

        var reader = new StringReader(map);

        while (true)
        {
            var line = reader.ReadLine();
            if (line == null)
                break;

            var names = line.Split("-");

            var cave1 = caves.SingleOrDefault(c => c.Name == names[0]);
            if (cave1 == null)
            {
                cave1 = new Cave(names[0]);
                caves.Add(cave1);
            }

            var cave2 = caves.SingleOrDefault(c => c.Name == names[1]);
            if (cave2 == null)
            {
                cave2 = new Cave(names[1]);
                caves.Add(cave2);
            }

            cave1.Caves.Add(cave2);
            cave2.Caves.Add(cave1);

        }

        return caves.OrderBy(c => c.Order).ThenBy(c => c.Name).ToList();
    }
}