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

    for (int i = 0; i < list.Count(); i++)
    {
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
            }
        }
        else
        {
            notsafe++;
        }

        // 
        if (i == list.Count - 2)
        {
            if (notsafe <= 0)
            {
                return true;
            }
            else
            {
                return checkAllVarients(list);
            }
        }
        else
        {
            curr = next;
            next = list[i + 2];
        }
    }

    return false;
}
bool checkForSafeSecond(List<int> list)
{
    int curr = list[0];
    int next = list[1];
    int count = 0;
    int notsafe = 0;
    int increasing = 0; // 0 unused, 1 inc, 2 dec

    for (int i = 0; i < list.Count(); i++)
    {
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
            }
        }
        else
        {
            notsafe++;
        }

        if (i == list.Count - 2)
        {
            if (notsafe <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            curr = next;
            next = list[i + 2];
        }
    }

    return false;
}

foreach (List<int> list in inputList)
{
    if (checkForSafe(list))
    {
        Console.WriteLine("Safe list found: " + string.Join(", ", list));
        answer++;
    }
}


bool checkAllVarients(List<int> list)
{
    List<List<int>> currVarients = new List<List<int>>();
    for (int i = 0; i < list.Count; i++)
    {
        List<int> tempList = new List<int>(list);
        tempList.RemoveAt(i);
        currVarients.Add(tempList);
    }

    bool salvagable = false;
    foreach (List<int> varients in currVarients)
    {
        if (!salvagable)
        {
            salvagable = checkForSafeSecond(varients);
        }
    }
    if (salvagable)
    {
        Console.WriteLine("List that could be salvaged: " + string.Join(", ", list));
        answer++;
    }

    return false;
}

Console.WriteLine(answer);