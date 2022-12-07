using Day7;

string[] input = File.ReadAllLines("input.txt");

var tree = new Tree("/");

var currentNode = tree.Root;
foreach (string line in input.Skip(1))
{
    if (line.StartsWith("$ cd"))
    {
        string dir = line[5..];
        if (dir == "..")
            currentNode = currentNode.Parent!;
        else
            currentNode = currentNode.Children.First(n => n.Name == dir);
    }
    else if (line.StartsWith("$ ls"))
    {
        continue;
    }
    else if (line.StartsWith("dir"))
    {
        currentNode.AddChild(new TreeNode { Name = line[4..], NodeType = NodeType.Directory });
    }
    else
    {
        string[] values = line.Split(' ');
        currentNode.AddChild(new TreeNode { Name = values[1], NodeType = NodeType.File, Size = int.Parse(values[0])});
    }
}

Console.WriteLine(tree.Print());
tree.Root.CalcSize();

// Part 1
Console.WriteLine(Helpers.SizeRecurse(tree.Root));

// Part 2
int fsSize = 70_000_000;
int updateSize = 30_000_000;
int used = tree.Root.Size;
int toFree = updateSize - (fsSize - used);

Console.WriteLine($"Used space: {used}/{fsSize}");
Console.WriteLine($"Update requires freeing {toFree} units");
var target = tree.Root.EnumerateDirectories()
                      .OrderBy(d => d.Size)
                      .First(d => d.Size >= toFree);
Console.WriteLine($"Target for deletion: {target.Name} - {target.Size} units");