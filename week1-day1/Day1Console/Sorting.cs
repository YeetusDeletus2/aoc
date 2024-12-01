namespace Day1Console;

public class Sorting
{
    public static void Sort(List<int> list, int lo, int hi)
    {
        for (int i = lo + 1; i <= hi; i++)
        {
            int key = list[i];  // The element to be placed in its correct position
            int j = i - 1;

            // Move elements of list[lo..i-1] that are greater than key to one position ahead of their current position
            while (j >= lo && list[j] > key)
            {
                list[j + 1] = list[j];  // Shift element to the right
                j--;
            }
            list[j + 1] = key;  // Insert the key at the correct position
        }
    }
}