// initialize variables - graded assignments 

/*
int currentAssignments = 5;

int sophia1 = 90;
int sophia2 = 86;
int sophia3 = 87;
int sophia4 = 98;
int sophia5 = 100;

int andrew1 = 92;
int andrew2 = 89;
int andrew3 = 81;
int andrew4 = 96;
int andrew5 = 90;

int emma1 = 90;
int emma2 = 85;
int emma3 = 87;
int emma4 = 98;
int emma5 = 68;

int logan1 = 90;
int logan2 = 95;
int logan3 = 87;
int logan4 = 88;


int sophiaSum = sophia1+sophia2+sophia3+sophia4+sophia5;
int andrewSum = andrew1+andrew2+andrew3+andrew4+andrew5;
int emmaSum = emma1+emma2+emma3+emma4+emma5;
int loganSum = logan1+logan2+logan3+logan4;
var sophiaScore = (decimal)sophiaSum / currentAssignments;
var andrewScore = (decimal) andrewSum/currentAssignments;
var emmaScore = (decimal) emmaSum/currentAssignments;
var loganScore = (decimal) loganSum/currentAssignments;

Console.WriteLine("Student\t\tGrade\n");
Console.WriteLine("Sophia:\t\t" + sophiaScore + "\tA-");
Console.WriteLine("Andrew:\t\t" + andrewScore + "\tB+");
Console.WriteLine("Emma:\t\t" + emmaScore + "\tB");
Console.WriteLine("Logan:\t\t" + loganScore + "\tA-");

Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();*/

//int[] sophiaScores = new int[5];

int currentAssignments = 5;

// initialize variables - graded assignments 
int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };
int[] beckyScores = new int[] { 92, 91, 90, 91, 92, 92, 92 };
int[] chrisScores = new int[] { 84, 86, 88, 90, 92, 94, 96, 98 };
int[] ericScores = new int[] { 80, 90, 100, 80, 90, 100, 80, 90 };
int[] gregorScores = new int[] { 91, 91, 91, 91, 91, 91, 91 };    

// Student names
string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan", "Becky", "Chris", "Eric", "Gregor" };

int[] studentScores = new int[10];
string currentStudentLetterGrade = "";
Console.WriteLine("Student\t\tGrade\n");
foreach (string name in studentNames)
{
    string currentStudent = name;

    if (currentStudent == "Sophia")
        studentScores = sophiaScores;

    else if (currentStudent == "Andrew")
        studentScores = andrewScores;

    else if (currentStudent == "Emma")
        studentScores = emmaScores;

    else if (currentStudent == "Logan")
       studentScores = loganScores;
    else if (currentStudent == "Becky") 
         studentScores = beckyScores;
    else if (currentStudent == "Chris")
          studentScores = chrisScores;
    else if (currentStudent == "Eric")
          studentScores = ericScores;
    else if (currentStudent == "Gregor")
          studentScores = gregorScores;
    //continue;

    // initialize/reset the sum of scored assignments
    int sumAssignmentScores = 0;
    int gradeAssignments = 0;
    // initialize/reset the calculated average of exam + extra credit scores
    decimal currentStudentGrade = 0;

    foreach (int score in studentScores)
    {
        gradeAssignments += 1; //increment the number of graded assignments
        if (gradeAssignments <= currentAssignments)
            // add the exam score to the sum
            sumAssignmentScores += score;
        else
            sumAssignmentScores += score / 10; // extra credit assignments are worth 10% of a regular assignment
    }


    currentStudentGrade = (decimal)(sumAssignmentScores) / currentAssignments;

    if (currentStudentGrade >= 97)
        currentStudentLetterGrade = "A+";

    else if (currentStudentGrade >= 93)
        currentStudentLetterGrade = "A";

    else if (currentStudentGrade >= 90)
        currentStudentLetterGrade = "A-";

    else if (currentStudentGrade >= 87)
        currentStudentLetterGrade = "B+";

    else if (currentStudentGrade >= 83)
        currentStudentLetterGrade = "B";

    else if (currentStudentGrade >= 80)
        currentStudentLetterGrade = "B-";

    else if (currentStudentGrade >= 77)
        currentStudentLetterGrade = "C+";

    else if (currentStudentGrade >= 73)
        currentStudentLetterGrade = "C";

    else if (currentStudentGrade >= 70)
        currentStudentLetterGrade = "C-";

    else if (currentStudentGrade >= 67)
        currentStudentLetterGrade = "D+";

    else if (currentStudentGrade >= 63)
        currentStudentLetterGrade = "D";

    else if (currentStudentGrade >= 60)
        currentStudentLetterGrade = "D-";

    else
        currentStudentLetterGrade = "F";

    //Console.WriteLine($"{name}\t\t{currentStudentGrade}\t?");
Console.WriteLine($"{currentStudent}\t\t{currentStudentGrade}\t{currentStudentLetterGrade}");
} 
Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();

