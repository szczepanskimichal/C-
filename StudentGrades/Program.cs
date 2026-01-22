using System;

namespace Ex2
{
    class Program2
    {
        static void Main()
        {
            string StudentName = "Alice Johnson";
            string course1Name = "English 101";
            string course2Name = "Algebra 201";
            string course3Name = "Biology 301";
            string course4Name = "English 401";
            string course5Name = "Computer Science 501";

            int course1Credits = 3;
            int course2Credits = 3;
            int course3Credits = 4;
            int course4Credits = 4;
            int course5Credits = 3;

            int gradeA = 4;
            int gradeB = 3;

            int course1Grade = gradeA;
            int course2Grade = gradeB;
            int course3Grade = gradeA;
            int course4Grade = gradeA;
            int course5Grade = gradeB;

            
            int totalCreditHours = 0;
            totalCreditHours += course1Credits;
            totalCreditHours += course2Credits;
            totalCreditHours += course3Credits;
            totalCreditHours += course4Credits;
            totalCreditHours += course5Credits;

            int totalGradePoints = 0;
            totalGradePoints += course1Credits * course1Grade;
            totalGradePoints += course2Credits * course2Grade;
            totalGradePoints += course3Credits * course3Grade;
            totalGradePoints += course4Credits * course4Grade;
            totalGradePoints += course5Credits * course5Grade;

            decimal gradePointsAverage = (decimal)totalGradePoints / totalCreditHours;
            
            //Console.WriteLine($"{totalGradePoints} {totalCreditHours}");

            int leadingDigit = (int)gradePointsAverage;
            int firstDigit=(int)(gradePointsAverage *10) %10;
            int secondDigit = (int)(gradePointsAverage *100) %10;
            
            Console.WriteLine($"Student: {StudentName}\n");
            Console.WriteLine("Course\t\t\tGrade\tCredit Hours");

            Console.WriteLine($"{course1Name}\t\t{course1Grade}\t\t{course1Credits}");
            Console.WriteLine($"{course2Name}\t\t{course2Grade}\t\t{course2Credits}");
            Console.WriteLine($"{course3Name}\t\t{course3Grade}\t\t{course3Credits}");
            Console.WriteLine($"{course4Name}\t\t{course4Grade}\t\t{course4Credits}");
            Console.WriteLine($"{course5Name}\t{course5Grade}\t\t{course5Credits}");

            Console.WriteLine($"\nFinal GPA:\t\t{leadingDigit}.{firstDigit}{secondDigit}");
        }
    }
}