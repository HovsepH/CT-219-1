public class Program
{
    public static void Main()
    {
        NumberPairFinder finder = new NumberPairFinder(50, 30);
        finder.DisplayNumbers();
        finder.FindPair();
        finder.DisplayResult();

    }
}

public class NumberPairFinder
{
    private List<int> numbers = new List<int>();
    private Dictionary<string, int> matchedPairObj = new Dictionary<string, int>();
    private int targetNumber;
    private int size;
    private bool pairFound;
     public NumberPairFinder(int size, int targetNumber)
    {
        this.size = size;
        this.targetNumber = targetNumber;
        GenerateNumbers();
    }

    private void GenerateNumbers()
    {
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            numbers.Add(random.Next(0, i + 1));
        }
    }

    public void DisplayNumbers()
    {
        Console.WriteLine(string.Join(" ", numbers));
    }

    public void FindPair()
    {
        for (int index1 = 0; index1 < numbers.Count; index1++)
        {
            int number1 = numbers[index1];

            for (int index2 = 0; index2 < numbers.Count; index2++)
            {
                if (index1 == index2) continue;

                int number2 = numbers[index2];
                if (number1 + number2 == targetNumber)
                {
                    matchedPairObj["number1"] = number1;
                    matchedPairObj["number2"] = number2;
                    matchedPairObj["index1"] = index1;
                    matchedPairObj["index2"] = index2;
                    pairFound = true;
                    break;
                }
            }

            if (pairFound)
                break;
        }
    }

    public void DisplayResult()
    {
        if (!pairFound)
        {
            Console.WriteLine("\nNo pairs found that sum to the target value.");
        }
        else
        {
            Console.WriteLine($"\nMatched numbers: [{matchedPairObj["number1"]}, {matchedPairObj["number2"]}]");
            Console.WriteLine($"Matched indexes: [{matchedPairObj["index1"]}, {matchedPairObj["index2"]}]");
        }
    }
}