using System;

class Program
{
    static void Main()
    {
        bool continueLoop;
        do
        {
            var student = new Student();

            // Input student name
            Console.Write("Enter student name: ");
            student.Name = Console.ReadLine()?.Trim() ?? "Unknown";

            // Input/validate 3 assignment marks (0-100)
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

            // Calculate and display results
            int total = GradeCalculator.CalculateTotal(student.AssignmentMarks);
            char grade = GradeCalculator.GetLetterGrade(total);
            
            Console.WriteLine($"\n{student.Name}'s Results:");
            Console.WriteLine($"Total Marks: {total}/100");
            Console.WriteLine($"Letter Grade: {grade}\n");

            // Continue/exit with input validation
            int choice;
            do
            {
                Console.Write("Continue? (0=Yes, 1=No): ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 0 && choice != 1));
            
            continueLoop = choice == 0;

        } while (continueLoop);
    }
}