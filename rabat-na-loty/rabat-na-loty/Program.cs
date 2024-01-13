using System;

class Program
{
    static void Main()
    {
        
        // pobieranie danych od uzytkownika
        Console.Write("Podaj swoją datę urodzenia w formacie RRRR-MM-DD: ");
        DateTime dataUrodzenia = PobierzDate();
        
        Console.Write("Podaj datę wylotu w formacie RRRR-MM-DD: ");
        DateTime dataWylotu = PobierzDate();
        //
        Console.Write("Czy lot jest krajowy (T/N)? ");
        bool lotKrajowy = PobierzTakLubNie();
        
        Console.Write("Czy jesteś stałym klientem (T/N)? ");
        bool stalyKlient = PobierzTakLubNie();

        double rabat = ObliczRabat(dataUrodzenia, dataWylotu, lotKrajowy, stalyKlient);

        WyswietlWynik(dataUrodzenia, dataWylotu, lotKrajowy, stalyKlient, rabat);
    }
    
    static DateTime PobierzDate()
    {
        DateTime date;
        while (!DateTime.TryParse(Console.ReadLine(), out date))
        {
            Console.Write("Niepoprawny format daty. Podaj datę w formacie RRRR-MM-DD: ");
        }

        return date;
    }

    static bool PobierzTakLubNie()
    {
        string input = Console.ReadLine().Trim().ToUpper();;

        while (input != "T" && input != "N")
        {
            Console.WriteLine("Niepoprawna odpowiedź. Wpisz 'T' lub 'N'.");
            Console.Write("Spróbuj ponownie: ");
            input = Console.ReadLine().Trim().ToUpper();
        }

        return input == "T";
    }

    static void WyswietlWynik(DateTime dataUrodzenia, DateTime dataWylotu, bool lotKrajowy, bool stalyKlient, double rabat)
    {
        Console.WriteLine();
        Console.WriteLine("=== Do obliczeń przyjęto:");
        Console.WriteLine($" * Data urodzenia: {dataUrodzenia.ToShortDateString()}");
        Console.WriteLine($" * Data lotu: {dataWylotu.ToLongDateString()}. Lot {(lotKrajowy ? "krajowy" : "międzynarodowy")}");
        Console.WriteLine($" * Stały klient: {(stalyKlient ? "Tak" : "Nie")}");
        Console.WriteLine();
        Console.WriteLine($"Przysługuje Ci rabat w wysokości: {rabat}%");
        Console.WriteLine($"Data wygenerowania raportu: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }

    static bool WSezonie(DateTime dataWylotu)
    {
        int rok = dataWylotu.Year;
        DateTime swietaPoczatek = new DateTime(rok, 12, 20);
        DateTime swietaKoniec = new DateTime(rok + 1, 1, 10);
        DateTime feriePoczatek = new DateTime(rok, 3, 20);
        DateTime ferieKoniec = new DateTime(rok + 1, 4, 10);

        if (dataWylotu >= swietaPoczatek && dataWylotu <= swietaKoniec) return true;
        if (dataWylotu >= feriePoczatek && dataWylotu <= ferieKoniec) return true;
        if (dataWylotu.Month == 7 || dataWylotu.Month == 8) return true;

        return false;
    }

    static double ObliczRabat(DateTime dataUrodzenia, DateTime dataWylotu, bool lotKrajowy, bool stalyKlient)
    {
        DateTime obecnaData = DateTime.Now;
        int wiek = ObliczWiek(dataUrodzenia, obecnaData);
        bool lotWSezonie = WSezonie(dataWylotu);

        double rabatNiemowlat = lotKrajowy ? 0.8 : 0.7;
        double rabatMlodziezy = 0.1;
        double rabatWczesnaRezerwacja = 0.1;
        double rabatLotPozaSezonem = lotKrajowy ? 0.15 : 0;
        
        double rabat = 0;
        
        if (wiek < 2)
        {
            rabat += rabatNiemowlat;
        } else if (wiek >= 2 && wiek <= 16)
        {
            rabat = rabatMlodziezy;
        }

        if (obecnaData < dataWylotu.AddMonths(-5))
        {
            rabat += rabatWczesnaRezerwacja;
        }
        
        if (lotKrajowy && !lotWSezonie)
        {
            rabat += rabatLotPozaSezonem;
        }
        
        if (stalyKlient && wiek >= 18)
        {
            rabat += 0.15;
        }
        
        return Math.Min(rabat, wiek < 2 ? 0.8 : 0.3) * 100;
    }
    
    static int ObliczWiek(DateTime dataUrodzenia, DateTime obecnaData)
    {
        int wiek = obecnaData.Year - dataUrodzenia.Year;
        if (obecnaData.DayOfYear < dataUrodzenia.DayOfYear)
        {
            wiek--;
        }
        return wiek;
    }
}
