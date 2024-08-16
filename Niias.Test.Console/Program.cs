using Niias.Test.Model;
using Niias.Test.Model.Data;

var intro = "Commands: /exit /commands /clear /parks /station /scheme /routes ";
Console.WriteLine(intro);
var station = StationCreator.CreateTeststation();
var work = true;
while (work) {
    var command = Console.ReadLine();
    switch (command) {
        case "/exit":
            work = false;
            break;
        case "/commands":
            Console.WriteLine(intro);
            break;
        case "/clear":
            Console.Clear();
            Console.WriteLine(intro);
            break;
        case "/parks":
            Console.WriteLine("Parks:");
            foreach (var park in station.Parks) {
                Console.WriteLine($"\n\tPark: {park.Name}");
                Console.WriteLine($"\tPaths:");
                var paths = "";
                var nodes = "Nodes:";
                foreach (var path in park.Paths) {
                    paths += $"Path {path.Name}, ";
                    nodes += $"\n\t{string.Join("\t", path.BorderNodes.Select(x => $"{x.Name}"))}";
                }
                Console.WriteLine($"\t{string.Join(", ", park.Paths.Select(x => $"{x.Name}"))}");
                Console.WriteLine($"\t{nodes}");
            }
            break;
        case "/station":
            Console.WriteLine("Station:");
            Console.WriteLine(station.Name);
            Console.WriteLine();
            Console.WriteLine("Sections:");
            Console.WriteLine($"Id\tName");
            foreach (var section in station.Sections.OrderBy(x => x.Id)) {
                Console.WriteLine($"{section.Id}\t{section.Name}");
            }
            break;
        case "/scheme":
            Console.WriteLine("TestStation\n");
            Console.WriteLine(@"               A");
            Console.WriteLine(@"           ____1___                B");
            Console.WriteLine(@"lp1_1___7_/____2___\26_22_20_______4___________2_rp1");
            Console.WriteLine(@"lp2__\__/_9____3_______/__\________5__________/__rp2");
            Console.WriteLine(@"     3  5            24  18 \16    C      /6  4");
            Console.WriteLine(@"                             \_____6_____/");
            Console.WriteLine(@"                            14\____7____/8");
            Console.WriteLine(@"                             12\___8___/10");           
            Console.WriteLine();
            break;
        case "/routes":
            Console.WriteLine("Enter start path name or id:");
            var start = Console.ReadLine();
            var startPath = GetPath(station, start);
            if (startPath == null) {
                Console.WriteLine("Path not found\nBreak");
                continue;
            }
            Console.WriteLine($"Start path:\tId: {startPath.Id},\tName: {startPath.Name}");
            Console.WriteLine("Enter end path name or id:");
            var end = Console.ReadLine();
            var endPath = GetPath(station, end);
            if (endPath == null) {
                Console.WriteLine("Path not found\nBreak");
                continue;
            }
            Console.WriteLine($"Start path:\tId: {startPath.Id},\tName: {startPath.Name}\nEnd path:\tId: {endPath.Id},\tName: {endPath.Name}");
            Console.WriteLine("short(s) or all(a)?");
            var type = Console.ReadLine();
            if (type == "short" || type == "s") {
                var route = station.GetShortRoute(startPath, endPath);
                if (route.Count() == 0) {
                    Console.WriteLine("Routes not found\nBreak");
                    continue;
                }
                Console.WriteLine("Route:\nSection name:");
                foreach (var routePath in route) {
                    Console.WriteLine($"\t{routePath?.Name}");
                }
            }
            else if (type == "all" || type == "a") {
                var routes = station.GetAllRoutes(startPath, endPath);
                if (routes.Count() == 0) {
                    Console.WriteLine("Routes not found\nBreak");
                    continue;
                }
                Console.WriteLine("Routes:\n");
                foreach (var route in routes) {
                    Console.WriteLine("\tRoute:\n\tSection name:");
                    foreach (var routePath in route) {
                        Console.WriteLine($"\t\t{routePath?.Name}");
                    }
                }               
            }
            else {
                Console.WriteLine("Invalid command\nBreak");
            }
            break;
        default:
            Console.WriteLine("Invalid command");
            break;
    }
}

Section? GetPath(Station station, string? data) {
    var path = station.Sections.FirstOrDefault(s => s.Name == data);
    if (path == null && int.TryParse(data, out var res)) {
        path = station.Sections.FirstOrDefault(s => s.Id == res);
    }
    return path;
}
