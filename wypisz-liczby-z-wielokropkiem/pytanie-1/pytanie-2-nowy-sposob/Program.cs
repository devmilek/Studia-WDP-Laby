// See https://aka.ms/new-console-template for more information

string wejscie = Console.ReadLine();
int[] dane = Array.ConvertAll<string, int>(wejscie.Split(" "), int.Parse);

var a = Convert.ToInt16(dane[0]);
var b = Convert.ToInt16(dane[1]);
var c = Convert.ToInt16(dane[2]);

if (a > b)
{
    a = Convert.ToInt16(dane[1]);
    b = Convert.ToInt16(dane[0]);
}

if (c < 0)
{
    return;
}

var wynikowyTekst = "";
    
for (int i = a + 1; i < b; i++)
{
    if (i % c == 0)
    {
        wynikowyTekst += $"{i}";
        if (i < b - c)
        {
            wynikowyTekst += " ";
        }
    }
}

// Console.WriteLine(wynikowyTekst);

var tablicaWynikow = wynikowyTekst.Split(" ");

var iloscNumerow = tablicaWynikow.Length;

// Console.WriteLine($"Ilosc numerow {iloscNumerow}");
// Console.WriteLine($"wynikowy tekst '{wynikowyTekst}'");

if (string.IsNullOrWhiteSpace(wynikowyTekst))
{
    Console.WriteLine("empty");
    return;
}

if (iloscNumerow > 10)
{
    Console.WriteLine($"{tablicaWynikow[0]}, {tablicaWynikow[1]}, {tablicaWynikow[2]}, ..., {tablicaWynikow[tablicaWynikow.Length - 2]}, {tablicaWynikow[tablicaWynikow.Length - 1]}");
    return;
}

for (int i = 0; i < iloscNumerow; i++)
{
    Console.Write(tablicaWynikow[i]);
    if (i < iloscNumerow - 1)
    {
        Console.Write(", ");
    }
}