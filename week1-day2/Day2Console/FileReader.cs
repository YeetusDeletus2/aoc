using System.Diagnostics.CodeAnalysis;

namespace Day2Console;

public class FileReader
{
    [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
    public List<List<int>> readFile(string input)
    {
        List<List<int>> output = new List<List<int>>();
        string line = "";

        List<int> currList = new List<int>();

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
                    currList.Add(int.Parse(str));
                }
                
                output.Add(currList);

                numbers = new string[] {};
                currList = new List<int>();
                
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