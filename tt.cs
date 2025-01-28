using System;
using System.Linq;

public static class Constants
{
    public const int AGradeMin = 90;  // 90-100 = A
    public const int BGradeMin = 80;  // 80-89 = B
    public const int CGradeMin = 70;  // 70-79 = C
    public const int DGradeMin = 60;  // 60-69 = D
}

public static class GradeCalculator
{
    public static int CalculateTotal(int[] marks) => 
        (int)Math.Round(marks.Average());

    public static bool ValidateMarks(int mark) => 
        mark >= 0 && mark <= 100;

    public static char GetLetterGrade(int total)
    {
        if (total >= Constants.AGradeMin)
            return 'A';
        else if (total >= Constants.BGradeMin)
            return 'B';
        else if (total >= Constants.CGradeMin)
            return 'C';
        else if (total >= Constants.DGradeMin)
            return 'D';
        else
            return 'F';
    }
}

public class Student
{
    public string Name { get; set; }
    public int[] AssignmentMarks { get; set; } = new int[3];
}

class Program
{
    static void Main()
    {
        bool continueLoop;
        do
        {
            var student = new Student();

            Console.Write("Enter student name: ");
            student.Name = Console.ReadLine()?.Trim() ?? "Unknown";

            for (int i = 0; i < 3; i++)
            {
                int mark;
                bool isValid;
                do
                {
                    Console.Write($"Enter mark for Assignment {i + 1}: ");
                    isValid = int.TryParse(Console.ReadLine(), out mark) && 
                            GradeCalculator.ValidateMarks(mark);
                    
                    if (!isValid)
                        Console.WriteLine("Invalid input! Enter a number between 0-100.");
                        
                } while (!isValid);
                
                student.AssignmentMarks[i] = mark;
            }

            int total = GradeCalculator.CalculateTotal(student.AssignmentMarks);
            char grade = GradeCalculator.GetLetterGrade(total);
            
            Console.WriteLine($"\n{student.Name}'s Results:");
            Console.WriteLine($"Total Marks: {total}/100");
            Console.WriteLine($"Letter Grade: {grade}\n");

            int choice;
            do
            {
                Console.Write("Continue? (0=Yes, 1=No): ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 0 && choice != 1));
            
            continueLoop = choice == 0;

        } while (continueLoop);
    }
}