// See https://aka.ms/new-console-template for more information

var a = new int[] {-2, -1, 0, 1, 4};
var b = new int[] {-2, -1, 0, 1, 4, 5, 6};

static void Print(int[] a, int[] b)
{
    string foundedNums = "";
    for (int indexA = 0; indexA < a.Length; indexA++)
    {
        var foundAinB = false;
        for (int indexB = 0; indexB < b.Length; indexB++)
        {
            // Console.WriteLine($"poronuje wlasnie {a[indexA]} z {b[indexB]}");
            if (a[indexA] == b[indexB])
            {
                foundAinB = true;
                break;
            }
        }
        if (!foundAinB && !foundedNums.Contains(a[indexA].ToString()))
        {
            foundedNums += a[indexA] + " ";
        }
    }

    if (foundedNums == "")
    {
        Console.WriteLine("empty");
    }
    else
    {
        Console.WriteLine(foundedNums);
    }
}

Print(a, b);