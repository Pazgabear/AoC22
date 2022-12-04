string[] input = File.ReadAllLines("input.txt");

// Part 1
int countP1 = 0;
foreach (string line in input)
{
    string[] ranges = line.Split(',');

    string[] r1 = ranges[0].Split('-');
    int r1min = int.Parse(r1[0]);
    int r1max = int.Parse(r1[1]);

    string[] r2 = ranges[1].Split('-');
    int r2min = int.Parse(r2[0]);
    int r2max = int.Parse(r2[1]);

    if (r1max - r1min < r2max - r2min)
    {
        if (r1min >= r2min && r1max <= r2max)
            countP1++;
    }
    else
    {
        if (r2min >= r1min && r2max <= r1max)
            countP1++;
    }
}

Console.WriteLine(countP1);

// Part 2
int countP2 = 0;
foreach (string line in input)
{
    string[] ranges = line.Split(',');

    string[] r1split = ranges[0].Split('-');
    int r1min = int.Parse(r1split[0]);
    int r1max = int.Parse(r1split[1]);

    string[] r2split = ranges[1].Split('-');
    int r2min = int.Parse(r2split[0]);
    int r2max = int.Parse(r2split[1]);

    var r1 = Enumerable.Range(r1min, r1max - r1min + 1);
    var r2 = Enumerable.Range(r2min, r2max - r2min + 1);

    var intersect = r1.Intersect(r2);
    if (intersect.Any())
        countP2++;
}

Console.WriteLine(countP2);