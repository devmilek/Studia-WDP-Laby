using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(TrianglePerimeter(1, 1, 1, 3));
        }
        
        /// <summary>
        /// Oblicza obwód trójkąta dowolnego dla zadanych długości boków, zaokrąglając wynik do podanej liczby cyfr po przecinku
        /// </summary>
        /// <param name="a">długość pierwszego boku, liczba całkowita nieujemna</param>
        /// <param name="b">długość drugiego boku, liczba całkowita nieujemna</param>
        /// <param name="c">długość trzeciego boku, liczba całkowita nieujemna</param>
        /// <param name="precision">dokładność obliczeń (zaokrąglenie), liczba cyfr po przecinku (od 2 do 8)</param>
        /// <returns>obwód trójkąta obliczony z zadaną dokładnością</returns>
        /// <exception cref="ArgumentOutOfRangeException">z komunikatem "wrong arguments", 
        ///     gdy <c>precision</c> jest poza przedziałem od 2 do 8 lub którakolwiek z długości jest ujemna</exception>    
        /// <exception cref="ArgumentException">z komunikatem "object not exist", gdy trójkąta nie można utworzyć</exception>
        /// <remarks>dopuszczamy trójkąt o pokrywających się bokach lub o wszystkich bokach o długości 0</remarks>
        public static double TrianglePerimeter(int a, int b, int c, int precision=2)
        {
            double obwod = a + b + c;
            return Math.Round(obwod, precision);
        }
    }
}