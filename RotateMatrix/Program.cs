public class Matrix
{
    private int[,] matrix;

    public Matrix(int size)
    {
        PopulateWithRandomValues(size);
    }

    private void PopulateWithRandomValues(int size)
    {
        Random random = new Random();
        matrix = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = random.Next(0, 10);
            }
        }
    }

    public void RotateClockwise()
    {
        int n = matrix.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                int temp = matrix[i, j];
                matrix[i, j] = matrix[j, i];
                matrix[j, i] = temp;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                int temp = matrix[i, j];
                matrix[i, j] = matrix[i, n - j - 1];
                matrix[i, n - j - 1] = temp;
            }
        }
    }

    public void DisplayMatrix()
    {
        int size = matrix.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        int size = 5;
        Matrix matrix = new Matrix(size);
        matrix.DisplayMatrix();
        matrix.RotateClockwise();
        matrix.DisplayMatrix();
    }
}