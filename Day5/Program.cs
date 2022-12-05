using Day5;

string[] input = File.ReadAllLines("input.txt");

var initialState = input.TakeWhile(l => !string.IsNullOrWhiteSpace(l)).Reverse();
int stackCount = int.Parse(initialState.First().Reverse().First(c => !char.IsWhiteSpace(c)).ToString());

var stacks = new Stack<string>[stackCount];
for (int i = 0; i < stackCount; ++i)
    stacks[i] = new Stack<string>();

foreach (string line in initialState.Skip(1))
{
    for (int i = 0; i < stackCount; ++i)
    {
        string box = line.Substring(i * 4, 3);
        if (string.IsNullOrWhiteSpace(box))
            continue;

        stacks[i].Push(box.Trim());
    }
}

Console.WriteLine(Helpers.GetStacksDisplay(stacks));

var operations = input.SkipWhile(l => !string.IsNullOrWhiteSpace(l)).Skip(1);
using var writer = new StreamWriter(File.OpenWrite("out.txt"));
foreach (string op in operations)
{
    string[] t = op.Split(' ');
    int count = int.Parse(t[1]);
    int sourceStack = int.Parse(t[3]) - 1;
    int destinationStack = int.Parse(t[5]) - 1;

    /*
    // Part 1
    for (int i = 0; i < count; ++i)
        stacks[destinationStack].Push(stacks[sourceStack].Pop());
    */

    // Part 2
    var boxes = new List<string>();
    for (int i = 0; i < count; ++i)
        boxes.Add(stacks[sourceStack].Pop());

    boxes.Reverse();
    foreach (string box in boxes)
        stacks[destinationStack].Push(box);
}

Console.WriteLine(Helpers.GetStacksDisplay(stacks));