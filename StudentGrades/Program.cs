using System;
using System.Linq;

namespace StudentGrades
{
    internal class Program
    {
        static void Main()
        {
            int currentAssignments = 5;

            string[] names = { "Sophia", "Nicolas", "Zahirah", "Jeong" };
            int[][] scores =
            {
                new[] { 93, 87, 98, 95, 100 },   // Sophia
                new[] { 80, 83, 82, 88, 85  },   // Nicolas
                new[] { 84, 96, 73, 85, 79  },   // Zahirah
                new[] { 90, 92, 98, 100, 97 }    // Jeong
            };

            Console.WriteLine("Student     Grade");
            for (int i = 0; i < names.Length; i++)
            {
                double average = scores[i].Sum() / (double)currentAssignments;
                string letter = GetLetterGrade(average);
                Console.WriteLine("{0,-10} {1,5:F1}  {2}", names[i], average, letter);
            }
        }

        static string GetLetterGrade(double avg)
        {
            if (avg >= 90) return "A";
            if (avg >= 80) return "B";
            if (avg >= 70) return "C";
            if (avg >= 60) return "D";
            return "F";
        }
    }
}