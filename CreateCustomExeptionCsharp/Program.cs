﻿namespace CreateCustomExeptionCsharp;

class Program
{
    static void Main(string[] args)
    {
        int Number1, Number2, Result;
        try
        {
            Console.WriteLine("Enter First Number");
            Number1 = int.Parse(Console.ReadLine() ?? "");
            Console.WriteLine("Enter Second Number");
            Number2 = int.Parse(Console.ReadLine() ?? "");

            if (Number2 % 2 > 0)
            {
                // OddNumberException ONE = new OddNumberException();
                // throw ONE;
                throw new OddNumberException();
            }
            Result = Number1 / Number2;
            Console.WriteLine($"Result: {Result}");
        }
        catch (OddNumberException one)
        {
            Console.WriteLine($"Message: {one.Message}");
            Console.WriteLine($"HelpLink: {one.HelpLink}");
            Console.WriteLine($"Source: {one.Source}");
            Console.WriteLine($"StackTrace: {one.StackTrace}");
        }

        Console.WriteLine("End of the Program");
    }
}
