using System;

class Program
{
    static void Main(string[] args)
    {
        // DisplayWelcome - Display the Welcome  message
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        // PromptUserName - Ask for and returns the user's name 
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        // PromptUserNumber - Ask for and returns the user's favorite number (as an integer)
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        // SquareNumber - to accept an integer as a parameter and returns that number squared (as an integer).
        static int SquareNumber(int number)
        {
            return number * number;
        }

        // DisplayResult - to accept the user's name and the squared number and displays them.
        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        }

        Console.WriteLine("Hello World! Welcome to the functions Project program.");
        Console.WriteLine();

        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);

    }
}