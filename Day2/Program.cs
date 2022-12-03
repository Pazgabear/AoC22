string[] input = File.ReadAllLines("input.txt");

// Part1
int p1Score = 0;
foreach (string line in input)
{
    string[] match = line.Split(' ');

    string p1 = match[0];
    string p2 = match[1];

    int matchScore = 0;
    if (p2 == "X")
    {
        matchScore += 1;

        if (p1 == "A")
            matchScore += 3;
        else if (p1 == "C")
            matchScore += 6;
    }
    else if (p2 == "Y")
    {
        matchScore += 2;

        if (p1 == "A")
            matchScore += 6;
        else if (p1 == "B")
            matchScore += 3;
    }
    else if (p2 == "Z")
    {
        matchScore += 3;

        if (p1 == "B")
            matchScore += 6;
        else if (p1 == "C")
            matchScore += 3;
    }

    p1Score += matchScore;
}

Console.WriteLine(p1Score);

// Part 2
int p2Score = 0;
foreach (string line in input)
{
    string[] match = line.Split(' ');

    string p1 = match[0];
    string p2 = match[1];

    int matchScore = 0;
    if (p2 == "X")
    {
        // Lose
        matchScore += 0;

        if (p1 == "A")
            matchScore += 3;
        else if (p1 == "B")
            matchScore += 1;
        else if (p1 == "C")
            matchScore += 2;
    }
    else if (p2 == "Y")
    {
        // Draw
        matchScore += 3;

        if (p1 == "A")
            matchScore += 1;
        else if (p1 == "B")
            matchScore += 2;
        else if (p1 == "C")
            matchScore += 3;
    }
    else if (p2 == "Z")
    {
        // Win
        matchScore += 6;

        if (p1 == "A")
            matchScore += 2;
        else if (p1 == "B")
            matchScore += 3;
        else if (p1 == "C")
            matchScore += 1;
    }

    p2Score += matchScore;
}

Console.WriteLine(p2Score);