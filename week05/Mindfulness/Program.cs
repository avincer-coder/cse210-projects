using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    BreathingActivity();
                    break;
                case "2":
                    ReflectionActivity();
                    break;
                case "3":
                    ListingActivity();
                    break;
                case "4":
                    GratitudeActivity();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    static void BreathingActivity()
    {
        StartMessage("Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.");
        int duration = GetDuration();
        for (int i = 0; i < duration / 6; i++)
        {
            Console.Write("Breathe in... "); Countdown(3);
            Console.Write("Breathe out... "); Countdown(3);
        }
        EndMessage("Breathing Activity", duration);
    }

    static void ReflectionActivity()
    {
        StartMessage("Reflection Activity", "This activity helps you reflect on times you showed strength and resilience.");
        int duration = GetDuration();
        List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        Thread.Sleep(3000);
        
        List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?",
            "What did you learn from this experience?",
            "How can you apply this lesson in the future?"
        };
        
        for (int i = 0; i < duration / 5; i++)
        {
            Console.WriteLine(questions[rand.Next(questions.Count)]);
            Countdown(5);
        }
        EndMessage("Reflection Activity", duration);
    }

    static void ListingActivity()
    {
        StartMessage("Listing Activity", "This activity helps you list positive aspects of your life.");
        int duration = GetDuration();
        Console.WriteLine("List as many positive things in your life as you can:");
        Countdown(duration);
        Console.WriteLine("Great job! You focused on the positive aspects of your life.");
        EndMessage("Listing Activity", duration);
    }
    
    static void GratitudeActivity()
    {
        StartMessage("Gratitude Activity", "This activity helps you reflect on things you are grateful for.");
        int duration = GetDuration();
        List<string> prompts = new List<string>
        {
            "Think of three things you are grateful for today.",
            "What is something someone did for you recently that made you happy?",
            "What place, object, or memory are you most grateful for right now?"
        };
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        Countdown(duration);
        EndMessage("Gratitude Activity", duration);
    }
    
    static void StartMessage(string name, string description)
    {
        Console.Clear();
        Console.WriteLine($"Starting {name}...");
        Console.WriteLine(description);
        Thread.Sleep(3000);
    }
    
    static void EndMessage(string name, int duration)
    {
        Console.WriteLine("Good job! You have completed this activity.");
        Console.WriteLine($"You spent {duration} seconds in {name}.");
        Countdown(3);
    }
    
    static int GetDuration()
    {
        Console.Write("Enter duration (seconds): ");
        return int.Parse(Console.ReadLine());
    }
    
    static void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
