// See https://aka.ms/new-console-template for more information

static void Print(int[] a, int[] b)
{
    string aInB = "";
    int indexA = 0;
    int indexB = 0;

    while (indexA < a.Length && indexB < b.Length)
    {
        if (a[indexA] == b[indexB])
        {
            if (aInB == "" || a[indexA] != a[indexA - 1])
            {
                aInB += a[indexA] + " ";
            }
            indexA++;
            indexB++;
        }
        else if (a[indexA] < b[indexB])
        {
            indexA++;
        }
        else
        {
            indexB++;
        }
    }

    if (aInB == "")
    {
        Console.WriteLine("empty");
    }
    else
    {
        Console.WriteLine(aInB);
    }
}

int[] a1 = { -2, -1, 0, 1, 4 };
int[] b1 = { -3, -2, -1, 1, 2, 3 };
Print(a1, b1);

int[] a2 = { 1, 2, 3 };
int[] b2 = { -3, -2, -1 };
Print(a2, b2);