using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Write a series of numbers we will make a list and work with it press 0 when your done.");
        List<int> numbers = new List<int>();
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Your number is: ");
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"Sum: {sum}");
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"Average: {average}");
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"Max number is {max}");

        int? smallestPositive = null;
        foreach (int number in numbers)
        {
            if (number > 0 && (smallestPositive == null || number < smallestPositive))
            {
                smallestPositive = number;
            }
        }

        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        
        numbers.Sort();
        Console.WriteLine("New list order by lowest value to higher: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}