using System;

class Program
{
    public static void Print(int[] a, int[] b)
    {
        int i = 0, j = 0;
        bool printed = false;

        while (i < a.Length || j < b.Length)
        {
            if (i < a.Length && (j == b.Length || a[i] < b[j]))
            {
                Console.Write(a[i] + " ");
                i++;
                while (i < a.Length && a[i] == a[i - 1])
                    i++;
                printed = true;
            }
            else if (j < b.Length && (i == a.Length || a[i] > b[j]))
            {
                Console.Write(b[j] + " ");
                j++;
                while (j < b.Length && b[j] == b[j - 1])
                    j++;
                printed = true;
            }
            else
            {
                i++;
                j++;
                while (i < a.Length && a[i] == a[i - 1])
                    i++;
                while (j < b.Length && b[j] == b[j - 1])
                    j++;
            }
        }

        if (!printed)
            Console.WriteLine("empty");
        else
            Console.WriteLine();
    }

    static void Main()
    {
        int[] a1 = { -2, -1, 0, 1, 4 };
        int[] b1 = { -3, -2, -1, 1, 2, 3 };
        Print(a1, b1);

        int[] a2 = { 0, 1, 1, 2, 3, 3, 3 };
        int[] b2 = { 0, 1, 2, 3, 3 };
        Print(a2, b2);
    }
}