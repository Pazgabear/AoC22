string input = File.ReadAllText("input.txt");

var data = input.Split("\n\n").Select(s => s.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)));

// Part 1
int max = 0;
foreach (var item in data)
{
    int sum = item.Sum();
    if (max < sum)
        max = sum;
}

Console.WriteLine(max);

// Part 2
var orderedData = data.OrderByDescending(item => item.Sum());
int total = orderedData.Take(3).Sum(item => item.Sum());

Console.WriteLine(total);