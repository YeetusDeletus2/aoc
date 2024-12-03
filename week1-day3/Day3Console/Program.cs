// See https://aka.ms/new-console-template for more information

using Day2Console;

long answer = 0;

FileReader fr = new FileReader();

List<List<string>> inputList =
    fr.readFile("C:\\Users\\irisp\\Desktop\\aoc\\week1-day3\\Day3Console\\input.txt");

List<int> allMultiplies(List<List<string>> inputList)
{
    List<int> multipliesList = new List<int>();
    bool go = true;

    foreach (List<string> outsideList in inputList)
    {
        foreach (string s in outsideList)
        {
            int countCorrect = 0;
            int countText = 0;
            int currNumber = 0;
            int tempList = 1;
            
            foreach (char c in s)
            {
                if (c == 'm')
                {
                    countCorrect++;
                }

                else if (c == 'd')
                {
                    countText++;
                }

                else if (countCorrect != 0)
                {
                    switch (countCorrect)
                    {
                        case 1:
                            if (c == 'u')
                            {
                                countCorrect++;
                                break;
                            }

                            countCorrect = 0;
                            break;
                        case 2:
                            if (c == 'l')
                            {
                                countCorrect++;
                                break;
                            }

                            countCorrect = 0;
                            break;
                        case 3:
                            if (c == '(')
                            {
                                countCorrect++;
                                break;
                            }

                            countCorrect = 0;
                            break;
                        case 4:
                            if (c >= 48 && c <= 57)
                            {
                                currNumber = currNumber * 10 + (c - 48);
                                break;
                            }

                            if (c == ',')
                            {
                                tempList *= currNumber;
                                currNumber = 0;
                                break;
                            }

                            if (c == ')')
                            {
                                tempList *= currNumber;
                                if (go)
                                {
                                    multipliesList.Add(tempList);
                                }

                                countCorrect = 0;
                                break;
                            }

                            countCorrect = 0;
                            break;
                    }

                    if (countCorrect == 0)
                    {
                        currNumber = 0;
                        tempList = 1;
                    }
                }
                else if (countText != 0)
                {
                    switch (countText)
                    {
                        case 1:
                            if (c == 'o')
                            {
                                countText++;
                                break;
                            }

                            countText = 0;
                            break;
                        case 2:
                            if (c == '(')
                            {
                                countText++;
                                break;
                            }

                            if (c == 'n')
                            {
                                countText++;
                                break;
                            }

                            countText = 0;
                            break;
                        case 3:
                            if (c == ')')
                            {
                                go = true;
                                countText = 0;
                                break;
                            }

                            else if (c == 39)
                            {
                                countText++;
                                break;
                            }

                            countText = 0;
                            break;
                        case 4:
                            if (c == 't')
                            {
                                countText++;
                                break;
                            }

                            countText = 0;
                            break;
                        case 5:
                            if (c == '(')
                            {
                                countText++;
                                break;
                            }

                            countText = 0;
                            break;
                        case 6:
                            if (c == ')')
                            {
                                go = false;
                            }

                            countText = 0;
                            break;
                    }
                }
            }
        }
    }

    return multipliesList;
}

List<int> multiplyList = allMultiplies(inputList);

for (int i = 0; i < multiplyList.Count; i++)
{
    answer += multiplyList[i];
}

Console.WriteLine(answer);