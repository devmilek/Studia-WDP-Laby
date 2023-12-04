static void Print(int[] a, int[] b)
{
    int i = 0, j = 0;
    bool isEmpty = true;
    int? lastPrinted = null;

    while (i < a.Length && j < b.Length)
    {
        if (a[i] < b[j])
        {
            if (!lastPrinted.HasValue || a[i] != lastPrinted.Value)
            {
                Console.Write(a[i] + " ");
                isEmpty = false;
                lastPrinted = a[i];
            }
            i++;
        }
        else if (b[j] < a[i])
        {
            if (!lastPrinted.HasValue || b[j] != lastPrinted.Value)
            {
                Console.Write(b[j] + " ");
                isEmpty = false;
                lastPrinted = b[j];
            }
            j++;
        }
        else
        {
            i++;
            j++;
        }
    }

    while (i < a.Length)
    {
        if (!lastPrinted.HasValue || a[i] != lastPrinted.Value)
        {
            Console.Write(a[i] + " ");
            isEmpty = false;
            lastPrinted = a[i];
        }
        i++;
    }

    while (j < b.Length)
    {
        if (!lastPrinted.HasValue || b[j] != lastPrinted.Value)
        {
            Console.Write(b[j] + " ");
            isEmpty = false;
            lastPrinted = b[j];
        }
        j++;
    }

    if (isEmpty)
    {
        Console.Write("empty");
    }
}

var a = new int[] {0, 1, 1, 2, 3, 3, 3};
var b = new int[] {0, 1, 2, 3, 3};

Print(a, b);