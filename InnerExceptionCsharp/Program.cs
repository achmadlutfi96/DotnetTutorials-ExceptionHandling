﻿using System.Text;

namespace InnerExceptionCsharp;

class Program
{
    static void Main(string[] args)
    {
        // Outer Try
        try
        {
            int FirstNumber, SecondNumber, Result;
            // Inner Try
            try
            {
                // Make sure to cause Exception in the Try Block
                Console.WriteLine("Enter First Number:");
                FirstNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Second Number:");
                SecondNumber = Convert.ToInt32(Console.ReadLine());

                Result = FirstNumber / SecondNumber;
                Console.WriteLine($"Result = {Result}");
            }
            // Inner Catch
            catch (Exception ex)
            {
                // Make sure this Path Does Not Exist
                string filePath = @"D:\Projects\LogFile\Log.txt";
                if (File.Exists(filePath))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append($"Message: {ex.Message} \n");
                    stringBuilder.Append($"Source: {ex.Source} \n");
                    stringBuilder.Append($"HelpLink: {ex.HelpLink} \n");
                    stringBuilder.Append($"StackTrace: {ex.StackTrace} \n");
                    stringBuilder.Append($"GetType(): {ex.GetType()} \n");
                    stringBuilder.Append($"GetType().Name: {ex.GetType().Name}");

                    StreamWriter streamWriter = new StreamWriter(filePath);
                    streamWriter.Write(stringBuilder.ToString());
                    streamWriter.Close();
                    Console.WriteLine("There is a Problem! Please Try Later");
                }
                else
                {
                    // To retain the Original Exception pass, this exceptionsm as a parameter
                    // to the constructor of the current exception
                    string Message = filePath + " Does Not Exist";
                    throw new FileNotFoundException(Message, ex);
                }
            }
        }
        // Outer Catch
        catch (Exception exception)
        {
            //exception.Message will give the current exception message
            //i.e. Message about File Not Found Exception
            Console.WriteLine("\nCurrent Exception Details: ");
            Console.WriteLine($"Current Exception Message: {exception.Message}");
            Console.WriteLine($"Current Exception Source: {exception.Source}");
            Console.WriteLine($"Current Exception StackTrace: {exception.StackTrace}");
            //Check if InnerException is not null before accessing the InnerException properties
            //else, you may get Null Reference Excception
            if (exception.InnerException != null)
            {
                Console.WriteLine("\nInner Exception Details: ");
                Console.WriteLine($"Inner Exception Message: {exception.InnerException.Message}");
                Console.WriteLine($"Inner Exception Source: {exception.InnerException.Source}");
                Console.WriteLine($"Inner Exception StackTrace: {exception.InnerException.StackTrace}");
            }
        }
        Console.WriteLine("Main Method End");
    }
}
