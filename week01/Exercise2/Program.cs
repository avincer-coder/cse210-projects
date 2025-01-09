using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please wright your grade percentage? ");
        string percentage = Console.ReadLine();
        int grade = int.Parse(percentage);
        string letter = "";
        if (grade >= 97)
        {
            letter = "A, but it could be considered as an A+ nice 7u7r";
        }
        else if (grade >= 94)
        {
            letter = "A";
        }
        else if (grade >= 90)
        {
            letter = "A, but it could be considered as an A- :O";
        }
        else if (grade >= 87)
        {
            letter = "B+";
        }
        else if (grade >= 84)
        {
            letter = "B";
        }
        else if (grade >= 80)
        {
            letter = "B-";
        }
        else if (grade >= 77)
        {
            letter = "C+";
        }
        else if (grade >= 74)
        {
            letter = "C";
        }
        else if (grade >= 70)
        {
            letter = "C-";
        }
        else if (grade >= 67)
        {
            letter = "D+";
        }
        else if (grade >= 64)
        {
            letter = "D";
        }
        else if (grade >= 60)
        {
            letter = "D-";
        }
        else if (grade >= 57)
        {
            letter = "F, but it could be considered as an F+ jaja you still don't pass this course jaja";
        }
        else if (grade >= 50)
        {
            letter = "F";
        }
        else
        {
            letter = "F, but it could be considered as an F-. You need to consider seriously on studding more or looking to dedicate on something else :,c.";
        }
        Console.WriteLine($"You scored {letter}!");
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations your score is high enough to apply for the next course!");
        }
        else
        {
            Console.WriteLine("Your grade is too low to pass this course sorry  sis/bro :c we encourage you to try better next time!");
        }
    }
}