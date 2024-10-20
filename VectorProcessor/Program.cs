using System;

public class VectorProcessor
{
    private int[] sortedVector;
    private int size;

    public VectorProcessor(int size = 25)
    {
        this.size = size;
        CreateSortVector();
    }

    private void CreateSortVector()
    {
        Random random = new Random();
        sortedVector = new int[size];

        for (int i = 0; i < size; i++)
        {
            sortedVector[i] = random.Next(0, size / 2);
        }

        Array.Sort(sortedVector);
        Console.WriteLine("Original sorted vector: " + string.Join(", ", sortedVector));
    }

    public int RemoveDuplicates()
    {
        int n = sortedVector.Length;
        if (n == 0)
            return 0;

        int uniqueIndex = 0;

        for (int index = 1; index < n; index++)
        {
            if (sortedVector[index] != sortedVector[uniqueIndex])
            {
                uniqueIndex++;
                sortedVector[uniqueIndex] = sortedVector[index];
            }
        }

        for (int index = uniqueIndex + 1; index < n; index++)
        {
            sortedVector[index] = 0;
        }

        return uniqueIndex + 1;
    }

    public void DisplayResults()
    {
        Console.WriteLine("Sorted vector with duplicates removed: " + string.Join(", ", sortedVector));
    }

    public static void Main()
    {
        VectorProcessor vectorProcessor = new VectorProcessor();
        int k = vectorProcessor.RemoveDuplicates();
        Console.WriteLine($"\nk = {k}");
        vectorProcessor.DisplayResults();
    }
}
