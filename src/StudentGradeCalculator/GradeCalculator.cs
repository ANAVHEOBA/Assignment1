using System;
using System.Linq;

public static class GradeCalculator
{
    // Calculate average marks (out of 100)
    public static int CalculateTotal(int[] marks) => 
        (int)Math.Round(marks.Average());

    // Validate marks (0-100)
    public static bool ValidateMarks(int mark) => 
        mark >= 0 && mark <= 100;

    // Determine letter grade
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