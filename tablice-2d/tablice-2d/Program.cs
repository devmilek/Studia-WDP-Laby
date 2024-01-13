using System;

class Program
{
    static void Main()
    {
        // Wczytaj wymiary macierzy A
        string[] dimensionsA = Console.ReadLine().Split();
        int n1 = int.Parse(dimensionsA[0]);
        int m1 = int.Parse(dimensionsA[1]);

        // Wczytaj macierz A
        int[,] matrixA = ReadMatrix(n1, m1);

        // Wczytaj wymiary macierzy B
        string[] dimensionsB = Console.ReadLine().Split();
        int n2 = int.Parse(dimensionsB[0]);
        int m2 = int.Parse(dimensionsB[1]);

        // Wczytaj macierz B
        int[,] matrixB = ReadMatrix(n2, m2);

        // Sprawdź czy możliwe jest wykonanie iloczynu macierzowego
        if (m1 != n2)
        {
            Console.WriteLine("impossible");
            return;
        }

        // Oblicz iloczyn macierzowy
        int[,] resultMatrix = MultiplyMatrices(matrixA, matrixB);

        // Wypisz wynik
        PrintMatrix(resultMatrix);
    }

    static int[,] ReadMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            string[] rowValues = Console.ReadLine().Split();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = int.Parse(rowValues[j]);
            }
        }

        return matrix;
    }

    static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
    {
        int n = matrixA.GetLength(0);
        int m = matrixA.GetLength(1);
        int p = matrixB.GetLength(1);

        int[,] resultMatrix = new int[n, p];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < p; j++)
            {
                int sum = 0;
                for (int k = 0; k < m; k++)
                {
                    sum += matrixA[i, k] * matrixB[k, j];
                }
                resultMatrix[i, j] = sum;
            }
        }

        return resultMatrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
