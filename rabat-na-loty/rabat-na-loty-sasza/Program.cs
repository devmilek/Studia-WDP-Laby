using System;
using System.Globalization;
using Microsoft.VisualBasic;

class Program {
    static void Main() {
        int age = 0;
        bool isValid = false;
        DateTime userBirthDate = DateTime.MinValue;
        DateTime flightDate = DateTime.MinValue;
        bool isTravelingWithChild = false;
        int childAge = 0;
        

        while (!isValid) {
            Console.WriteLine("Podaj datę urodzenia w formacie RRRR-MM-DD: ");
            string userInput = Console.ReadLine();

            if (DateTime.TryParseExact(userInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out userBirthDate)) {
                age += CalculateAge(userBirthDate);
                if (userBirthDate > DateTime.Now) {
                    Console.WriteLine("Podano nieprawidłową datę urodzenia");
                }
                if(age < 14) {
                    System.Console.WriteLine("Osoby młodszi 14 lat nie mogą podrózować sami!");
                }
                else {
                    isValid = true;
                }
                }

            else {
                Console.WriteLine("Błędne dane");
            }
        }

        bool flag = false;
        string info = "";
        bool sezon = false;
        while (!flag) {
            Console.WriteLine("Podaj datę lotu w formacie RRRR-MM-DD: ");
            string userInput = Console.ReadLine();

            if (DateTime.TryParseExact(userInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out flightDate)) {
                if ((flightDate >= new DateTime(flightDate.Year, 3, 20) && flightDate <= new DateTime(flightDate.Year, 4, 10)) ||
                    (flightDate >= new DateTime(flightDate.Year, 12, 20) && flightDate <= new DateTime(flightDate.Year, 1, 1)) ||
                    (flightDate.Month == 7 || flightDate.Month == 8)) {
                    info = "Lot jest w sezonie";
                    sezon = true;
}
                if (flightDate < DateTime.Now) {
                    Console.WriteLine("Podano nieprawidłową datę lotu!");
                }
                else {
                    flag = true;
                }
            }
            else {
                Console.WriteLine("Błędne dane");
            }
        }

        Console.WriteLine("Czy podróżujesz z dzieckiem (poniżej 14 lat)? (T/N)");
        string answerChild = Console.ReadLine();
        if (answerChild.ToUpper() == "TAK" || answerChild.ToUpper() == "T") {
            isTravelingWithChild = true;

            bool flagChild = false;
            while (!flagChild) {
                Console.WriteLine("Podaj datę urodzenia dziecka w formacie RRRR-MM-DD:");
                string userInputChild = Console.ReadLine();

                if (DateTime.TryParseExact(userInputChild, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime childBirthDate)) {
                    if (childBirthDate > DateTime.Now) {
                        Console.WriteLine("Błędne dane.");
                    }
                    else {
                        childAge += CalculateAge(childBirthDate);
                        flagChild = true;
                    }
                }
                else {
                    Console.WriteLine("Podano nieprawidłową datę urodzenia dziecka.");
                }
            }
        }

        bool flag1 = false;
        string typeOfFlight = "";
        while (!flag1) {
            Console.WriteLine("Czy lot jest krajowym? ");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "TAK" || answer.ToUpper() == "T") {
                typeOfFlight += "Krajowy";
                flag1 = true;
            }
            else if (answer.ToUpper() == "NIE" || answer.ToUpper() == "N") {
                typeOfFlight += "Międzynarodowy";
                flag1 = true;
            }
            else {
                Console.WriteLine("Błędne dane");
            }
        }

        Console.WriteLine("Czy jesteś stałym klientem?");
        string answer1 = Console.ReadLine();
        string clientStatus = (answer1.ToUpper() == "TAK" || answer1.ToUpper() == "T") && age >= 18 ? "Tak" : "Nie";

        Console.Clear();
        Console.WriteLine("Informacje o kliencie:");
        System.Console.WriteLine();
        Console.WriteLine($"* Data urodzenia: {userBirthDate.ToString("yyyy-MM-dd")}");
        Console.WriteLine($"* Data lotu: {flightDate.ToString("dddd, d MMMM yyyy")}. {info}");
        Console.WriteLine($"* Typ lotu: {typeOfFlight}");
        Console.WriteLine($"* Stały klient: {clientStatus}");
        Console.WriteLine("_____________________________________");
        System.Console.WriteLine();

        // Rabaty na lot
        int rabat = CalculateDiscount(age, typeOfFlight, sezon, clientStatus, flightDate);
        Console.WriteLine($"Całkowita zniżka na Twój lot wynosi: {rabat} % ");

        // Rabat na lot dla dziecka
        if (isTravelingWithChild) {
            int childDiscount = CalculateChildDiscount(childAge, typeOfFlight);
            Console.WriteLine($"Całkowita zniżka na lot dla Twojego dziecka wynosi: {childDiscount} % ");
        }
        System.Console.WriteLine();
        System.Console.WriteLine($"Data wygenerowania raportu: {DateTime.Now}");
    }

    static int CalculateAge(DateTime birthDate) {
        int age = DateTime.Now.Year - birthDate.Year;
        if (DateTime.Now.DayOfYear < birthDate.DayOfYear) {
            age--;
        }
        return age;
    }

    static int CalculateDiscount(int age, string typeOfFlight, bool sezon, string clientStatus, DateTime flightDate) {
        int rabat = 0;
        if (clientStatus == "Tak") {
            Console.WriteLine("--Znizka dla klienta stałego 15%");
            rabat += 15;
    }
    if (age >= 14 && age <= 16 && (typeOfFlight == "Krajowy" || typeOfFlight == "Międzynarodowy")) {
        Console.WriteLine("--Znizka dla klienta 10%");
        rabat += 10;
    }
    if (typeOfFlight == "Międzynarodowy" && sezon == false) {
        Console.WriteLine("--Znizka dla klienta 15% (poza sezonem)");
        System.Console.WriteLine(sezon);
        rabat += 15;
    }


    // Dodanie rabatu za wcześniejszą rezerwację (10%)
    TimeSpan timeToFlight = flightDate - DateTime.Now;
    if (timeToFlight.TotalDays >= 5 * 30) {  // Sprawdzenie, czy rezerwacja nastąpiła co najmniej 5 miesięcy wcześniej
        Console.WriteLine("--Znizka za wcześniejszą rezerwację 10%");
        rabat += 10;
    }

    return rabat;
}

static int CalculateChildDiscount(int childAge, string typeOfFlight) {
    int childDiscount = 0;
    
    if (childAge < 2) {
        if (typeOfFlight == "Krajowy") {
            childDiscount += 80;
        }
        else if (typeOfFlight == "Międzynarodowy") {
            childDiscount += 70;
        }
    }
    else if (childAge >= 2 && childAge <= 14) {
        childDiscount += 10;
    }

    return childDiscount;
}
}