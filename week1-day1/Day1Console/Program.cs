using System.Runtime.InteropServices.Marshalling;
using Day1Console;


FileReader fr = new FileReader();

List<List<int>> inputLists = fr.readFile("\\Users\\irisp\\Desktop\\aoc\\week1-day1\\Day1Console\\input.txt");

Sorting.Sort(inputLists[0], 0, inputLists[0].Count - 1);
Sorting.Sort(inputLists[1], 0, inputLists[1].Count - 1);

int answer = 0;

for (int i = 0; i < inputLists[0].Count; i++)
{
    if (inputLists[0][i] > inputLists[1][i])
    {
        answer += inputLists[0][i] - inputLists[1][i];
    }
    else
    {
        answer += inputLists[1][i] - inputLists[0][i];
    }
}

Console.WriteLine(answer);



