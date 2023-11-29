static void Print(int[] a, int[] b)
{
    int i = 0, j = 0;

    while (i < a.Length && j < b.Length)
    {
        if (a[i] < b[j])
        {
            Console.Write(a[i] + " ");
            i++;
        }
        else if (a[i] > b[j])
        {
            Console.Write(b[j] + " ");
            j++;
        }
        else
        {
            // Liczby są równe, pomijamy i i j
            i++;
            j++;
        }
    }

    // Wypisz pozostałe liczby z a
    while (i < a.Length)
    {
        Console.Write(a[i] + " ");
        i++;
    }

    // Wypisz pozostałe liczby z b
    while (j < b.Length)
    {
        Console.Write(b[j] + " ");
        j++;
    }
}

int[] a1 = new int[] { -2, -1, 0, 1, 4 };
int[] b1 = new int[] { -3, -2, -1, 1, 2, 3 };
Print(a1, b1);
Console.WriteLine();

int[] a2 = new int[] { 0, 1, 1, 2, 3, 3, 3 };
int[] b2 = new int[] { 0, 1, 2, 3, 3 };
Print(a2, b2);
Console.WriteLine();