using System;

class Program
{
    static void Main()
    {
        // Wczytaj wymiary planszy
        string[] dimensions = Console.ReadLine().Split();
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        // Inicjalizacja planszy
        char[,] board = new char[rows, cols];

        // Wczytaj planszę
        for (int i = 0; i < rows; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < cols; j++)
            {
                board[i, j] = row[j];
            }
        }

        // Uzupełnij planszę liczbami
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (board[i, j] == '.')
                {
                    int mineCount = CountAdjacentMines(board, i, j, rows, cols);
                    board[i, j] = mineCount.ToString()[0];
                }
            }
        }

        // Wyświetl wynik
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(board[i, j]);
            }
            Console.WriteLine();
        }
    }

    static int CountAdjacentMines(char[,] board, int row, int col, int rows, int cols)
    {
        int count = 0;
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (i >= 0 && i < rows && j >= 0 && j < cols && board[i, j] == '*')
                {
                    count++;
                }
            }
        }
        return count;
    }
}