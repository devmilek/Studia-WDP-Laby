// See https://aka.ms/new-console-template for more information

string wejscie = Console.ReadLine();
int[] dane = Array.ConvertAll<string, int>(wejscie.Split(" "), int.Parse);

var a = Convert.ToInt16(dane[0]);
var b = Convert.ToInt16(dane[1]);
var c = Convert.ToInt16(dane[2]);

if (c < 0)
{
    return;
}

var iloscNumerow = 0;

for (int i = a + 1; i < b; i++)
{
    if (i % c == 0)
    {
        iloscNumerow++;
    }
}

// Console.WriteLine(iloscNumerow);

if (iloscNumerow <= 0)
{
    Console.WriteLine("empty");
    return;
}

if (iloscNumerow > 10)
{
    //JESLI NUMEROW JEST WIECEJ NIZ 10
    var numer = 0;
    var wynikowyTekst = "";
    
    for (int i = a + 1; i < b; i++)
    {
        if (i % c == 0)
        {
            wynikowyTekst += $"{i} ";
        }
    }

    var wynikowaTablica = wynikowyTekst.Split(" ");

    Console.WriteLine($"{wynikowaTablica[0]}, {wynikowaTablica[1]}, {wynikowaTablica[2]}, ..., {wynikowaTablica[wynikowaTablica.Length - 3]}, {wynikowaTablica[wynikowaTablica.Length - 2]}");
}
else
{
    for (int i = a + 1; i < b; i++)
    {
        if (i % c == 0)
        {
            Console.Write($"{i}");
            if (i <= b - 3)
            {
                Console.Write(", ");
            }
        }
    }
}