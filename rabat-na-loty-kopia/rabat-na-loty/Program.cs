using System;
using System.Globalization;

namespace rabat_na_loty
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Podaj swoją datę urodzenia w formacie RRRR-MM-DD:");
                var input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawny format daty. Spróbuj ponownie.");
                }
                
                
            }
        }
    }
}