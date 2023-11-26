string wejscie = Console.ReadLine();
int[] dane = Array.ConvertAll<string, int>(wejscie.Split(" "), int.Parse);

var a = Convert.ToInt16(dane[0]);
var b = Convert.ToInt16(dane[1]);

if (a > b)
{
    a = Convert.ToInt16(dane[1]);
    b = Convert.ToInt16(dane[0]);
}


var iloscNumerow = b - a - 1;

if (iloscNumerow <= 0)
{
    Console.WriteLine("empty");
    return;
}

if (iloscNumerow > 10)
{
    for(int i = a + 1; i < a + 4; i++)
    {
        Console.Write($"{i}, ");
    }
    Console.Write("..., ");
    for (int i = b - 2; i < b; i++)
    {
        Console.Write($"{i}");
        if (i < b - 1)
        {
            Console.Write(", ");
        }
    }
}
else
{
    for (int i = a; i < b - 1; i++)
    {
        Console.Write($"{i + 1}");
        if (i <= b - 3)
        {
            Console.Write(", ");
        }
    }
}