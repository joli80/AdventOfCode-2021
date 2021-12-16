// See https://aka.ms/new-console-template for more information

// https://adventofcode.com/2021/day/12
Console.WriteLine("Starting https://adventofcode.com/2021/day/12...");

string firstSystem = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";

SystemBuilder systemBuilder = new();
var caves = systemBuilder.Build(firstSystem);

foreach (var cave in caves)
{
    Console.WriteLine($"{cave} ({(cave.IsSmall ? "small" : "large")}): {string.Join(",", cave.Caves)}");
}


var paths = new PathFinder().Find(caves.First());
Console.WriteLine($"*** {paths.Count} PATHS ***");

foreach (var path in paths)
{
    Console.WriteLine($"{string.Join(",", path)}");
}