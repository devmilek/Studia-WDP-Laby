using System;

namespace pytanie_drugie;

class Program
{
    static void Main(string[] args)
    {
        // tu wpisz kod
        try
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            string input3 = Console.ReadLine();
            
            if (input1 == "" || input2 == "" || input3 == "")
            {
                throw new ArgumentException();
            }

            var a = Convert.ToInt32(input1);
            var b =  Convert.ToInt32(input2);
            var c =  Convert.ToInt32(input3);

            int calculate = checked(a * b * c);
            
            Console.WriteLine(calculate);
        }
        catch (FormatException)
        {
            Console.WriteLine("format exception, exit");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("argument exception, exit");
        }
        catch (OverflowException)
        {
            Console.WriteLine("overflow exception, exit");
        }
        catch (Exception)
        {
            Console.WriteLine("non supported exception, exit");
        }
        
    }
}