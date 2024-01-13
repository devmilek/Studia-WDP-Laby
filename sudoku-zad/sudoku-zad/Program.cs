using System;

class Program
{
    static void Main()
    {
        int[,] sudoku = new int[9, 9];
        for (int i = 0; i < 9; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            for (int j = 0; j < 9; j++)
            {
                sudoku[i, j] = int.Parse(line[j]);
            }
        }
        
        if (SprawdzSudoku(sudoku))
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }

    static bool SprawdzSudoku(int[,] board)
    {
        for (int i = 0; i < 9; i++)
        {
            if (!SprwadzWiersz(board, i) || !SprawdzKolumne(board, i))
            {
                return false;
            }
        }
        for (int i = 0; i < 9; i += 3)
        {
            for (int j = 0; j < 9; j += 3)
            {
                if (!SprawdzKwadrat(board, i, j))
                {
                    return false;
                }
            }
        }

        return true;
    }

    static bool SprwadzWiersz(int[,] board, int row)
    {
        bool[] seen = new bool[10];
        for (int i = 0; i < 9; i++)
        {
            int num = board[row, i];
            if (seen[num])
            {
                return false;
            }
            seen[num] = true;
        }
        return true;
    }

    static bool SprawdzKolumne(int[,] board, int col)
    {
        bool[] seen = new bool[10];
        for (int i = 0; i < 9; i++)
        {
            int num = board[i, col];
            if (seen[num])
            {
                return false;
            }
            seen[num] = true;
        }
        return true;
    }

    static bool SprawdzKwadrat(int[,] board, int startRow, int startCol)
    {
        bool[] seen = new bool[10];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int num = board[startRow + i, startCol + j];
                if (seen[num])
                {
                    return false;
                }
                seen[num] = true;
            }
        }
        return true;
    }
}
