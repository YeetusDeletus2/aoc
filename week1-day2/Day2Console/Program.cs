using System.Runtime.CompilerServices;
using Day2Console;

FileReader fr = new FileReader();

List<List<int>> inputList =
    fr.readFile("C:\\Users\\11897\\RiderProjects\\Huiswerk\\aoc\\week1-day2\\Day2Console\\input.txt");

List<List<int>> possibleToleratable = new List<List<int>>();

int answer = 0;

bool checkForSafe(List<int> list)
{
    int curr = list[0];
    int next = list[1];
    int count = 0;
    int notsafe = 0;
    int increasing = 0; // 0 unused, 1 inc, 2 dec
    foreach (int i in list)
    {
        count++;
        if (increasing == 0)
        {
            increasing = curr > next ? 2 : 1;
        }

        if (curr > next & increasing == 2)
        {
            // decreasing
            if (curr - 3 > next)
            {
                // too much, unsafe
                notsafe++;
            }
            else
            {
                // safe
            }
        }
        else if (curr < next & increasing == 1)
        {
            // increasing
            if (curr + 3 < next)
            {
                // too much, unsafe
                notsafe++;
            }
            else
            {
                // safe
            }
        }
        else
        {
            notsafe++;
        }

        try
        {
            curr = next;
            next = list[count + 1];
        }
        catch (Exception e)
        {
            if (notsafe <= 0)
            {
                return true;
            }
            else
            {
                possibleToleratable.Add(list);
            }
        }
    }

    return false;
}

foreach (List<int> list in inputList)
{
    if (checkForSafe(list))
    {
        answer++;
    }
}

List<List<List<int>>> allVarients = new List<List<List<int>>>();

foreach (List<int> list in possibleToleratable)
{
    List<List<int>> currVarients = new List<List<int>>();
    for (int i = 0; i < list.Count; i++)
    {
        List<int> tempList = new List<int>(list);
        tempList.RemoveAt(i);
        currVarients.Add(tempList);
    }
    allVarients.Add(currVarients);
}

foreach (List<List<int>> list in allVarients)
{
    bool salvagable = false;
    foreach (List<int> ints in list)
    {
        if (checkForSafe(ints))
        {
            salvagable = true;
        }
    }

    if (salvagable)
    {
        answer++;
    }
}

Console.WriteLine(answer);