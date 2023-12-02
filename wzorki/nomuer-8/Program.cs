namespace wzorki
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Print8(5);
            PrintZ(8);
        }

        public static void Print8(int width)
        {
            // Print uppper
            for (var i = 0; i < width; i++)
            {
                if (i == 0 || i == width)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("*");
                }
            }
        }

        public static void PrintZ(int width)
        {
            for (var i = width; i < width; i++)
            {
                Console.Write("*");
            }

            for (var i = 0; i < width - 2; i++)
            {
                for (var j = i; i )
            }
        }
    }
}

