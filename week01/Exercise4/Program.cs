using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the numbers.
        List<int> numbers = new List<int>();

        // Loop to get numbers from the user.
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = -1;
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        // Compute the sum.
        int sum = 0;
        foreach (int item in numbers)
        {
            sum += item;
        }

        // Compute the average.
        double average = (double)sum / numbers.Count;

        // Find the largest number.
        int max = 0;
        foreach (int item in numbers)
        {
            if (item > max)
            {
                max = item;
            }
        }

        // Display the results for sum,average and max.
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}