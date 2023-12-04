using System;

namespace pytanie_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var data = input.Split(' ');
            
            var rows = int.Parse(data[0]);
            var cols = int.Parse(data[1]);
            
            var matrix = new int[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                var row = Console.ReadLine();
                var rowData = row.Split(' ');
                
                for (var j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(rowData[j]);
                }
            }
            
            var transpozycja = new int[cols, rows];
            
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    transpozycja[j, i] = matrix[i, j];
                }
            }
            
            for (int i = 0; i < transpozycja.GetLength(0); i++)
            {
                for (int j = 0; j < transpozycja.GetLength(1); j++)
                {
                    Console.Write(transpozycja[i,j] + " ");
                }
                Console.WriteLine();
            }
            
        }
    }
}