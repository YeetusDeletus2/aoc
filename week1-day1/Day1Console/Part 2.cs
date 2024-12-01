using System.Runtime.InteropServices.Marshalling;
using Day1Console;

    FileReader fr = new FileReader();

    List<List<int>> inputLists = fr.readFile("\\Users\\irisp\\Desktop\\aoc\\week1-day1\\Day1Console\\input.txt");

    int answer = 0;

        foreach (int i in inputLists[0])
    {
        int similarity = 0;
        foreach (int j in inputLists[1])
        {
            if (i == j)
            {
                similarity++;
            }
        }

        answer += i * similarity;
    }

    Console.WriteLine(answer);
