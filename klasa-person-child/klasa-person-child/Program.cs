using System;

public class Person
{
    protected string familyName;
    protected string firstName;
    protected int age;

    public Person(string familyName, string firstName, int age)
    {
        modifyFirstName(firstName);
        modifyFamilyName(familyName);
        modifyAge(age);
    }

    public override string ToString()
    {
        return $"{firstName} {familyName} ({age})";
    }

    public void modifyFirstName(string newFirstName)
    {
        ValidateName(newFirstName);
        firstName = FormatName(newFirstName);
    }

    public void modifyFamilyName(string newFamilyName)
    {
        ValidateName(newFamilyName);
        familyName = FormatName(newFamilyName);
    }

    public void modifyAge(int newAge)
    {
        if (newAge < 0)
        {
            throw new ArgumentException("Age must be positive!");
        }
        age = newAge;
    }

    private void ValidateName(string name)
    {
        // if (string.IsNullOrWhiteSpace(name))
        // {
        //     throw new ArgumentException("Wrong name!");
        // }
        foreach (char c in name)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                throw new ArgumentException("Wrong name!");
            }
        }
    }

    private string FormatName(string name)
    {
        string formattedName = name.Replace(" ", "");
        formattedName = $"{char.ToUpper(formattedName[0])}{formattedName.Substring(1).ToLower()}";
        return formattedName;
    }
}

public class Child : Person
{
    private readonly Person mother;
    private readonly Person father;

    public Child(string familyName, string firstName, int age, Person mother = null, Person father = null)
        : base(familyName, firstName, age)
    {
        if (age > 15)
        {
            throw new ArgumentException("Child’s age must be less than 15!");
        }

        this.mother = mother;
        this.father = father;
    }

    public override string ToString()
    {
        string result = base.ToString() + Environment.NewLine;
        result += $"mother: {(mother != null ? mother.ToString() : "No data")}" + Environment.NewLine;
        result += $"father: {(father != null ? father.ToString() : "No data")}";
        return result;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Person p = new Person(familyName: " 4.!   ", firstName: "kris", age: 18);
            Console.WriteLine(p);
        }
        catch( Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}