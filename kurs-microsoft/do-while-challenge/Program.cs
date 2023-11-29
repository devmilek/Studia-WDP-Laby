var validNumber = false;
int numericValue = 0;

Console.WriteLine("Enter an integer value between 5 and 10");

do
{
    var input = Console.ReadLine();
    if (int.TryParse(input, out int result))
    {
        if (result > 10 || result < 5)
        {
            Console.WriteLine($"You entered {result}. Please enter a number between 5 and 10.");
        }
        else
        {
            numericValue = result;
            validNumber = true;   
        }

    }
    else
    {
        Console.WriteLine("Sorry, you entered an invalid number, please try again");
    }
} while(!validNumber);

Console.WriteLine($"Your input value ({numericValue}) has been accepted.");