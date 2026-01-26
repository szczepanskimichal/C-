


using System;

namespace Ex2
{
    class Program2
    {
        static void Main()
        {
            string StudentName = "Alice Johnson";
            string course1Nmae = "English 101";
            string course2Nmae = "Algebra 201";
            string course3Nmae = "Biology 301";
            string course4Nmae = "English 401";
            string course5Nmae = "Computer Science 501";

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

            Console.WriteLine($"{course1Nmae} {course1Grade} {course1Credits}");
        }
    }
}

