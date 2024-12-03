using System.Diagnostics.CodeAnalysis;

namespace Day2Console;

public class FileReader
{
    [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
    public List<List<string>> readFile(string input)
    {
        List<List<string>> output = new List<List<string>>();
        string line = "";

        List<string> currList = new List<string>();

        try
        {
            StreamReader sr = new StreamReader(input);
            line = sr.ReadLine();
            while (line != null)
            {
                string[] numbers = line.Split(" ");
                // split string
                foreach (string str in numbers)
                {
                    currList.Add(str);
                }

                output.Add(currList);

                numbers = new string[] { };
                currList = new List<string>();

                line = sr.ReadLine();
            }

            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        return output;
    }
}