string permission = "Admin|Manager";
int level = 55;

if (level > 55 && permission.Contains("admin"))
{
    Console.WriteLine("Welcome, Super Admin user.");
} else if (level < 55 && permission.Contains("admin"))
{
    Console.WriteLine("Welcome, Admin user.");
} else if (level >= 20)
{
    Console.WriteLine("");
}