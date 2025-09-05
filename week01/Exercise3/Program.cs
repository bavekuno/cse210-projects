using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the magic letter game! ");

        // Step 1: Ask the user for the magic number.
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        int guess = -1; //  The guess  initialized value 

        // Step 2 & 3: Loop and check the guess
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
