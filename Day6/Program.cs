string input = File.ReadAllText("input.txt");

// Part 1
for (int i = 0; i < input.Length - 4; ++i)
{
    string chars = input.Substring(i, 4);

    if (chars.Distinct().Count() == 4)
    {
        Console.WriteLine(i + 4);
        break;
    }
}

// Part 2
for (int i = 0; i < input.Length - 14; ++i)
{
    string chars = input.Substring(i, 14);

    if (chars.Distinct().Count() == 14)
    {
        Console.WriteLine(i + 14);
        break;
    }
}