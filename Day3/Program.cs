string[] input = File.ReadAllLines("input.txt");

string priorities = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

// Part 1
int totalP1 = 0;
foreach (string line in input)
{
    int length = line.Length;
    if (length % 2 == 1)
        continue;

    string c1 = line[..(length / 2)];
    string c2 = line[(length / 2)..];

    char sharedType = c1.Intersect(c2).Single();

    totalP1 += priorities.IndexOf(sharedType) + 1;
}

Console.WriteLine(totalP1);

// Part 2
int totalP2 = 0;
for (int i = 0; i < input.Length / 3; ++i)
{
    string[] elves = input.Skip(i * 3).Take(3).ToArray();
    char result = elves[0].Intersect(elves[1]).Intersect(elves[2]).Single();

    totalP2 += priorities.IndexOf(result) + 1;
}

Console.WriteLine(totalP2);