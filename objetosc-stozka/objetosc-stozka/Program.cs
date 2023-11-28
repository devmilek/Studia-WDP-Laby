using System;

class Program
{
    static void Main()
    {
        try
        {
            // input uzytkownika
            string[] input = Console.ReadLine().Split();
            int r = int.Parse(input[0]);
            int l = int.Parse(input[1]);
            
            if (r < 0 || l < 0)
            {
                Console.WriteLine("ujemny argument");
                return;
            }

            // exception
            if (r > l)
            {
                Console.WriteLine("obiekt nie istnieje");
                return;
            }

            // objetosc
            double h = Math.Sqrt(l * l - r * r);
            double v = Math.PI * r * r * h / 3;
            
            int vFloor = (int)Math.Floor(v);
            int vCeil = (int)Math.Ceiling(v);

            // wyniki
            Console.WriteLine($"{Math.Floor(v)} {Math.Ceiling(v)}");
        }
        catch (Exception)
        {
            Console.WriteLine("blad");
        }
    }
}