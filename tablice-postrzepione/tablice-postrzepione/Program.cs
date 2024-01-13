using System;

class Program
{
    static char[][] ReadJaggedArrayFromStdInput()
    {
        int rows = int.Parse(Console.ReadLine());
        char[][] jaggedArray = new char[rows][];

        for (int i = 0; i < rows; i++)
        {
            string[] rowElements = Console.ReadLine().Split(' ');
            jaggedArray[i] = new char[rowElements.Length];

            for (int j = 0; j < rowElements.Length; j++)
            {
                jaggedArray[i][j] = char.Parse(rowElements[j]);
            }
        }

        return jaggedArray;
    }

    static char[][] TransposeJaggedArray(char[][] tab)
    {
        int rows = tab.Length;
        int cols = 0;
        
        for (int i = 0; i < rows; i++)
        {
            if (tab[i].Length > cols)
            {
                cols = tab[i].Length;
            }
        }

        char[][] transposedArray = new char[cols][];

        for (int i = 0; i < cols; i++)
        {
            transposedArray[i] = new char[rows];

            for (int j = 0; j < rows; j++)
            {
                if (i < tab[j].Length)
                {
                    transposedArray[i][j] = tab[j][i];
                }
                else
                {
                    transposedArray[i][j] = ' ';
                }
            }
        }

        return transposedArray;
    }

    static void PrintJaggedArrayToStdOutput(char[][] tab)
    {
        foreach (var row in tab)
        {
            foreach (var cell in row)
            {
                Console.Write(cell + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        char[][] jagged = ReadJaggedArrayFromStdInput();
        PrintJaggedArrayToStdOutput(jagged);
        jagged = TransposeJaggedArray(jagged);
        Console.WriteLine();
        PrintJaggedArrayToStdOutput(jagged);
    }
}
