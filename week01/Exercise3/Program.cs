using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;
        
        while(playAgain)
        {
            Random number = new Random();
            int randomNumber = number.Next(1, 101);

            int guess = -1;
            int attempts = 0;
            // I wrote this code line to displaya the random number on console for testing purposes 
            Console.WriteLine($"Answer: {randomNumber}");
         
            while (guess != randomNumber)
            {
                
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempts++;

                if (randomNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (randomNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"The answer is correct! The number of attempts was {attempts}");
                }
          
            }
            Console.Write("Would you like to play again? (yes/no): ");
            string answer = Console.ReadLine().ToLower(); // .ToLower() converts all characters in a string to lowercase

            if (answer != "yes" && answer != "y")
            {
                playAgain = false; // If the answer is not "yes" or "y", the while loop ends
            }
        }
        Console.WriteLine("Thank you for playing!");
    }
}