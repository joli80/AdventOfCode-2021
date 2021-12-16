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

string secondSystem = @"BC-gt
gt-zf
end-KH
end-BC
so-NL
so-ly
start-BC
NL-zf
end-LK
LK-so
ly-KH
NL-bt
gt-NL
start-zf
so-zf
ly-BC
BC-zf
zf-ly
ly-NL
ly-LK
IA-bt
bt-so
ui-KH
gt-start
KH-so";

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

Console.WriteLine("*************************************");

caves = systemBuilder.Build(secondSystem);

foreach (var cave in caves)
{
    Console.WriteLine($"{cave} ({(cave.IsSmall ? "small" : "large")}): {string.Join(",", cave.Caves)}");
}

paths = new PathFinder().Find(caves.First());
Console.WriteLine($"*** {paths.Count} PATHS ***");

// foreach (var path in paths)
// {
//     Console.WriteLine($"{string.Join(",", path)}");
// }

var oneSmallCave = paths.Where(p => p.Count(c => c.IsSmall) < 2).ToList();

Console.WriteLine($"*** At most one small cave: {oneSmallCave.Count} PATHS ***");

foreach (var path in oneSmallCave)
{
    Console.WriteLine($"{string.Join(",", path)}");
}