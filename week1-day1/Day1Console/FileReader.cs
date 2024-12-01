using System.Diagnostics.CodeAnalysis;

namespace Day1Console;

public class FileReader
{
    [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
    public List<List<int>> readFile(string input)
    {
        List<List<int>> output = new List<List<int>>();
        string line = "";

        List<int> firstList = new List<int>();
        List<int> secondList = new List<int>();

        try
        {
            StreamReader sr = new StreamReader(input);
            line = sr.ReadLine();
            while (line != null)
            {
                string[] numbers = line.Split("   ");
                // split string
                firstList.Add(int.Parse(numbers[0]));
                secondList.Add(int.Parse(numbers[1]));

                numbers[0] = null;
                numbers[1] = null;
                line = sr.ReadLine();
            }
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        output.Add(firstList);
        output.Add(secondList);
        
        return output;
    }
}